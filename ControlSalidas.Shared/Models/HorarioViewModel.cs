using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class HorarioViewModel
    {
        public bool Seleccionado { get; set; }
        public int DiaSemana { get; set; }
        public TimeOnly HoraEntrada { get; set; } = new(7, 0);
        public TimeOnly HoraSalida { get; set; } = new(13, 0);
    }
}
