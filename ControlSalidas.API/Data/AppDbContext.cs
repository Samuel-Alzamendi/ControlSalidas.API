using Microsoft.EntityFrameworkCore;
using ControlSalidas.Shared.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ControlSalidas.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Viatico> Viaticos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Salida> Salidas { get; set; }
    public DbSet<SalidaFuncionario> SalidaFuncionarios { get; set; }
    public DbSet<Hospital> Hospitales { get; set; }
    public DbSet<HorasSalidaFuncionario> HorasSalidaFuncionarios { get; set; }
    public DbSet<ResumenMensualFuncionario> ResumenesMensuales { get; set; }

}