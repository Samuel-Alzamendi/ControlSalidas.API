using ControlSalidas.API.Data;
using ControlSalidas.API.Models;
using Microsoft.AspNetCore.Mvc;

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
            .OrderBy(f => f.fechaSalida.ToDateTime(TimeOnly.MinValue)).Reverse()
            .Select(s =>
            {
                string estado = "";
                if (s.fechaSalida > hoy)
                {
                    estado = "Para salir";
                }
                else if (s.fechaLlegada < hoy)
                {
                    estado = "Finalizado";
                }
                else
                {
                    estado = "En curso";
                }

                return new
                {
                    s.id,
                    s.fechaSalida,
                    s.fechaLlegada,
                    s.noches,
                    s.salidasCalculadas,
                    estado
                };

            })
            .ToList();



        return Ok(salidas);
    }

    [HttpGet("Obtener_salidas_Funcionarios")]
    public IActionResult ObtenerSalidaFuncionario()
    {
        var salidaFuncionarios = _context.SalidaFuncionarios
            .OrderBy(f => f.salidaId)
            .ToList();

        return Ok(salidaFuncionarios);
    }


    [HttpGet("Obtener_hospitales")]
    public IActionResult ObtenerHospitales()
    {
        var hospitales = _context.Hospitales
            .OrderBy(f => f.departamento)
            .ToList();

        return Ok(hospitales);
    }
    #endregion

    #region Sets
    [HttpPost("Agregar_funcionarios")]
    public IActionResult AgregarFuncionario(RegistarFuncionarioRequest request)
    {
        if (request.Nombre.Trim() == "" || request.Cargo.Trim() == "")
        {
            return BadRequest("Error, usuario invalido");
        }
        else if (Math.Abs(request.Ci).ToString().Length < 8 || Math.Abs(request.Ci).ToString().Length > 8)
        {
            return BadRequest("Error, CI invalida");
        }
        else
        {
            var funcionario = new Funcionario
            {
                Ci = request.Ci,
                Nombre = request.Nombre,
                Cargo = request.Cargo
            };

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return Ok(funcionario);
        }
            
    }

    [HttpPost("Registrar_salida")]
    public IActionResult RegistrarSalida(RegistrarSalidaRequest request)
    {
        if(request.funcionariosIds == null)  
        {
            return BadRequest("Ningun funcionario seleccionado");
        } else if (request.fechaSalida.DayNumber > request.fechaLlegada.DayNumber)
        {
            return BadRequest("La fecha de salida no puede ser anterior a la fecha de llegada");
        }
        else if(request.hospitalId == null)
        {
            return BadRequest("Ningun hopital valido seleccionado");
        }
        else
        {

            var funcionarios = _context.Funcionarios
                    .Where(f => request.funcionariosIds.Contains(f.Id))
                    .ToList();

            //var funcionario = _context.Funcionarios
            //    .FirstOrDefault(f => f.id == request.funcionarioId);

            if (funcionarios == null)
            {
                return NotFound("Funcionarios no encontrado");
            }

            int dias = (request.fechaLlegada.Day - request.fechaSalida.Day) + 1;
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

            var hospital = _context.Hospitales
                .Where(f => request.hospitalId.Contains(f.id))
                .ToList();

            var salida = new Salida
            {
                fechaSalida = request.fechaSalida,
                fechaLlegada = request.fechaLlegada,
                dias = dias,
                noches = noches,
                salidasCalculadas = salidasCalculadas,
                hospital = hospital
            };
            _context.Salidas.Add(salida);
            _context.SaveChanges();

            foreach (var funcionario in funcionarios)
            {
                funcionario.CantidadSalidas += salidasCalculadas;
                funcionario.DiasFuera += dias;
                funcionario.Noches += noches;

                // averiguar porque los obj funcionario y salida no son accesibles en salida funcionario
                var salidaFuncionario = new SalidaFuncionario
                {
                    salidaId = salida.id,
                    salida = salida,
                    funcionario = funcionario

                };

                _context.SalidaFuncionarios.Add(salidaFuncionario);
                _context.SaveChanges();
            }


            return Ok(new
            {
                mensaje = "Salida registrada correctamente",
                dias,
                noches,
                salidasCalculadas,
                fechaSalida = salida.fechaSalida,
                fechaLlegada = salida.fechaLlegada,
                hospital = salida.hospital
            });

        }// else
    }//metodo

    [HttpPost("Agregar_hospital")]
    public IActionResult AgregarHospital(RegistrarHospitalRequest request)
    {

        var hospital = new Hospital
        {
            id = request.id,
            nombre = request.nombre,
            departamento = request.departamento,
            ciudad = request.ciudad
        };

        _context.Hospitales.Add(hospital);
        _context.SaveChanges();

        return Ok(hospital);
    }
    #endregion



}// class
