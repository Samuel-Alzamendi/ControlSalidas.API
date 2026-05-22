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

    [HttpGet("Obtener_funcionarios")]
    public IActionResult ObtenerFuncionarios()
    {
        var funcionarios = _context.Funcionarios
        .OrderBy(f => f.noches)
        .ThenBy(f => f.diasFuera)
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

    [HttpGet("Obtener_hospitales")]
    public IActionResult ObtenerHospitales()
    {
        var hospitales = _context.Hospitales
            .OrderBy(f => f.departamento)
            .ToList();

        return Ok(hospitales);
    }

    [HttpPost("Agregar_funcionarios")]
    public IActionResult AgregarFuncionario(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();

        return Ok(funcionario);
    }

    [HttpPost("Registrar_salida")]
    public IActionResult RegistrarSalida(RegistrarSalidaRequest request)
    {
        var funcionario = _context.Funcionarios
            .FirstOrDefault(f => f.id == request.funcionarioId);

        if (funcionario == null)
        {
            return NotFound("Funcionario no encontrado");
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

        var salida = new Salida
        {
            funcionarioId = funcionario.id,
            fechaSalida = request.fechaSalida,
            fechaLlegada = request.fechaLlegada,
            dias = dias,
            noches = noches,
            salidasCalculadas = salidasCalculadas
        };
        _context.Salidas.Add(salida);

        funcionario.cantidadSalidas += salidasCalculadas;
        funcionario.diasFuera += dias;
        funcionario.noches += noches;

        _context.SaveChanges();

        return Ok(new
        {
            mensaje = "Salida registrada correctamente",
            dias,
            noches,
            salidasCalculadas,
            salida
        });
    }

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


    

}// class
