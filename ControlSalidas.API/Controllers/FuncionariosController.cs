using ControlSalidas.API.Data;
using ControlSalidas.Shared.Models;
using ControlSalidas.Shared.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlSalidas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private AppDbContext _context;

    public FuncionariosController(AppDbContext context)
    {
        _context = context;
    }

    #region Gets
    [HttpGet("Obtener_funcionarios")]
    public IActionResult ObtenerFuncionarios()
    {
        var funcionarios = _context.Funcionarios
        .Include(f => f.Horarios)
        .OrderBy(f => f.Noches)
        .ThenBy(f => f.DiasFuera)
        .ToList();

        return Ok(funcionarios);
    }

    [HttpGet("Obtener_salidas")]
    public IActionResult ObtenerSalidas()
    {
        // da error
        // ni dios sabe porque

        var hoy = DateOnly.FromDateTime(DateTime.Now);


        var salidas = _context.Salidas
            .AsEnumerable()
            .OrderBy(f => f.FechaSalida.ToDateTime(TimeOnly.MinValue)).Reverse()
            .Select(s =>
            {
                string estado = "";
                if (s.FechaSalida > hoy)
                {
                    estado = "Para salir";
                }
                else if (s.FechaLlegada < hoy)
                {
                    estado = "Finalizado";
                }
                else
                {
                    estado = "En curso";
                }

                return new
                {
                    s.Id,
                    s.FechaSalida,
                    s.FechaLlegada,
                    s.Noches,
                    s.SalidasCalculadas,
                    estado,
                    s.IdFuncionarios
                };

            })
            .ToList();



        return Ok(salidas);
    }

    [HttpGet("Obtener_salidas_Funcionarios")]
    public IActionResult ObtenerSalidaFuncionario()
    {
        var salidaFuncionarios = _context.SalidaFuncionarios
            .OrderBy(sf => sf.SalidaId)
            .ToList();

        return Ok(salidaFuncionarios);
    }

    [HttpGet("Obtener_hospitales")]
    public IActionResult ObtenerHospitales()
    {
        var hospitales = _context.Hospitales
            .OrderBy(f => f.Departamento)
            .ToList();

        return Ok(hospitales);
    }
    #endregion

    #region Post
    [HttpPost("Agregar_funcionarios")]
    public IActionResult AgregarFuncionario(RegistarFuncionarioRequest request)
    {
        if (request.Nombre.Trim() == "" || request.Cargo.Trim() == "")
        {
            return BadRequest("Error, usuario invalido");
        }
        else if (request.Ci.ToString().Length < 8 || request.Ci.ToString().Length > 8)
        {
            return BadRequest("Error, CI invalida");
        }
        else
        {
            var funcionario = new Funcionario
            {
                Ci = request.Ci,
                Nombre = request.Nombre,
                Cargo = request.Cargo,
                Horarios = request.Horarios.Select(h => new HorarioLaboral
                {
                    DiaSemana = h.DiaSemana,
                    HoraEntrada = h.HoraEntrada,
                    HoraSalida = h.HoraSalida
                }).ToList()
            };

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            var resumen = new ResumenMensualFuncionario
            {
                FuncionarioId = funcionario.Id,
                Anio = DateTime.Now.Year,
                Mes = DateTime.Now.Month,
                HorasNormales = 0,
                HorasExtra = 0,
                CantidadSalidas = 0,
                DiasFuera = 0,
                Noches = 0
            };

            _context.ResumenesMensuales.Add(resumen);
            _context.SaveChanges();

            return Ok(funcionario);
        }

    }

    [HttpPost("Registrar_salida")]
    public IActionResult RegistrarSalida(RegistrarSalidaRequest request)
    {
        if (request.FuncionariosIds == null)
        {
            return BadRequest("Ningun funcionario seleccionado");
        } else if (request.FechaSalida.DayNumber > request.FechaLlegada.DayNumber)
        {
            return BadRequest("La fecha de salida no puede ser anterior a la fecha de llegada");
        }
        else if (request.HospitalesIds == null)
        {
            return BadRequest("Ningun hopital valido seleccionado");
        }else if(request.HorariosHastaQueHora.Length < ((request.FechaLlegada.Day - request.FechaSalida.Day) + 1)
            || request.HorariosHastaQueHora.Length > ((request.FechaLlegada.Day - request.FechaSalida.Day) + 1)) 
        {
            return BadRequest("Horario invalido o cantidad de horarios invalidos");
        }else if(request.HorariosHastaQueHora.Length != request.HorariosDesdeQueHora.Length)
        {
            return BadRequest("Horario de diferentes cantidades");
        }
        else
        {
            var funcionarios = _context.Funcionarios
                    .Where(f => request.FuncionariosIds.Contains(f.Id))
                    .ToList();

            

            //var funcionario = _context.Funcionarios
            //    .FirstOrDefault(f => f.id == request.funcionarioId);

            if (funcionarios == null)
            {
                return NotFound("Funcionarios no encontrado");
            }

            int dias = (request.FechaLlegada.Day - request.FechaSalida.Day) + 1;
            int noches = 0;
            if (dias >= 2)
            {
                noches = dias - 1;
            }
            else if (dias == 1)
            {
                noches = 0;
            }

            if (dias <= 0)
            {
                return BadRequest("La fecha de llegada debe ser posterior o igual a la fecha de salida");
            }

            int salidasCalculadas = 1;

            //var hospital = new Hospital
            //{
            //    id = request.hospital.id,
            //    ciudad = request.hospital.ciudad,
            //    departamento = request.hospital.departamento,
            //    nombre = request.hospital.nombre
            //};

            // no se esta usando porque se cambio por hospitales ids
            var hospitales = _context.Hospitales
                .Where(f => request.HospitalesIds.Contains(f.Id))
                .ToList();

            var salida = new Salida
            {
                FechaSalida = request.FechaSalida,
                FechaLlegada = request.FechaLlegada,
                Dias = dias,
                Noches = noches,
                SalidasCalculadas = salidasCalculadas,
                HospitalesIds = request.HospitalesIds,
                IdFuncionarios = request.FuncionariosIds
            };
            _context.Salidas.Add(salida);
            _context.SaveChanges();





            //-------------------------------------------------------------------------------------------------------
            // calcular horas y horas extra de los funcionarios, ns como hacerlo

            //int HastaQueHora = 0;
            //foreach(var hastaQueHoraFor in request.HorariosHastaQueHora)
            //{   if(hastaQueHoraFor.Hour > 22)
            //    {
            //        return BadRequest("Horario fuera de rango");
            //    }
            //    HastaQueHora = HastaQueHora + hastaQueHoraFor.Hour;
            //}

            //int[] cantHorasComunesF = new int[funcionarios.Count];
            //int[] horasTotal = new int[request.HorariosHastaQueHora.Length];
            //for(int i=0; i<funcionarios.Count; i++)
            //{
            //    foreach(var f in funcionarios)
            //    {
            //        cantHorasComunesF[i] = ((f.HorarioLaboralSalida.Hour - f.HorarioLaboralEntrada.Hour) +1);
            //    }
            //}

            foreach (var funcionario in funcionarios)
            {
                funcionario.CantidadSalidas += salidasCalculadas;
                funcionario.DiasFuera += dias;
                funcionario.Noches += noches;

                // calcular horas normales y extra
                double horasNormales = 0;
                double horasExtra = 0;

                for (int i = 0; i < request.HorariosHastaQueHora.Length; i++)
                {
                    var fechaActual = request.FechaSalida.AddDays(i);

                    bool esDiaLaboral = true;

                    // verifica que dia trabaja
                    var horarioFuncionario = funcionario.Horarios
                        .FirstOrDefault(h => h.DiaSemana == fechaActual.DayOfWeek);

                    // si no hay dia, significa que no le corresponde
                    // y las horas son totalmente extra
                    if (horarioFuncionario == null)
                    {
                        esDiaLaboral = false;
                    }

                    var horaInicioReal = request.HorariosDesdeQueHora[i];
                    var horaFinReal = request.HorariosHastaQueHora[i];

                    // Tope de las 22:00
                    if (horaFinReal > new TimeOnly(22, 0))
                    {
                        horaFinReal = new TimeOnly(22, 0);
                    }

                    double horasTrabajadas =
                        (horaFinReal.ToTimeSpan() -
                         horaInicioReal.ToTimeSpan())
                        .TotalHours;

                    if (esDiaLaboral)
                    {
                        double horasCorrespondientes =
                            (horarioFuncionario.HoraSalida -
                             horarioFuncionario.HoraEntrada)
                            .TotalHours;

                        // math.min devulve el numero minimo, osea el
                        // correspondinete a si es menos de su horario o horario completo
                        horasNormales += Math.Min(
                            horasTrabajadas,
                            horasCorrespondientes);
                        // en caso de las horas extra, devuelve el mas grande,
                        // que puede pasarse de las correspondientes, dando asi
                        // las horas extra en esa salida
                        horasExtra += Math.Max(
                            0,
                            horasTrabajadas - horasCorrespondientes);
                    }
                    else
                    {
                        horasExtra += horasTrabajadas;
                    }


                }

                Console.WriteLine(horasNormales);
                Console.WriteLine(horasExtra);

                var salidaFuncionario = new SalidaFuncionario
                {
                    SalidaId = salida.Id,
                    FuncionarioId = funcionario.Id
                };

                var horasSalida = new HorasSalidaFuncionario
                {
                    FuncionarioId = funcionario.Id,
                    SalidaId = salida.Id,
                    HorasNormales = horasNormales,
                    HorasExtra = horasExtra
                };

                _context.HorasSalidaFuncionarios.Add(horasSalida);
                _context.SaveChanges();

                _context.SalidaFuncionarios.Add(salidaFuncionario);
                _context.SaveChanges();
            }



            return Ok(new
            {
                mensaje = "Salida registrada correctamente",
                dias,
                noches,
                salidasCalculadas,
                fechaSalida = salida.FechaSalida,
                fechaLlegada = salida.FechaLlegada,
                hospital = salida.HospitalesIds
            });

        }// else
    }//metodo

    [HttpPost("Agregar_hospital")]
    public IActionResult AgregarHospital(RegistrarHospitalRequest request)
    {

        var hospital = new Hospital
        {
            Nombre = request.Nombre,
            Departamento = request.Departamento,
            Ciudad = request.Ciudad
        };

        _context.Hospitales.Add(hospital);
        _context.SaveChanges();

        return Ok(hospital);
    }
    #endregion



}// class
