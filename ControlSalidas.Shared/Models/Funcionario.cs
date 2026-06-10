using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Ci { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Cargo { get; set; } = "";
        public int Noches { get; set; } = 0;
        public int CantidadSalidas { get; set; } = 0;
        public int DiasFuera { get; set; } = 0;
        public TimeOnly HorarioLaboralEntrada { get; set; } = new TimeOnly(7, 0, 0);
        public TimeOnly HorarioLaboralSalida { get; set; } = new TimeOnly(13, 0, 0);
        public int cantidadHorasPertenecientes { get; set; } = 0;
        public int cantidadHorasExtra { get; set; } = 0;

    }
}
