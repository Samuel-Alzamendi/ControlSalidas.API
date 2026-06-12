using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Request
{
    public class HorarioLaboralRequest
    {
        // esta clase no se esta usando mas
        // se guarda por las dudas
        public int DiaSemana { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }
    }
}
