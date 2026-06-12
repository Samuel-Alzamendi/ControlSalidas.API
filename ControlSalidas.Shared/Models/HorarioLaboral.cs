using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class HorarioLaboral
    {
        public int Id { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }

    }
}
