using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Request
{
    public class RegistrarSalidaRequest
    {
        public List<int> FuncionariosIds { get; set; } = new List<int>();
        public List<int> HospitalesIds { get; set; } = new List<int>();
        public DateOnly FechaSalida { get; set; } = new DateOnly();
        public DateOnly FechaLlegada { get; set; } = new DateOnly();
        public TimeOnly[] HorariosDesdeQueHora { get; set; } = [];
        public TimeOnly[] HorariosHastaQueHora { get; set; } = [];
        
        //public TimeOnly HastaQueHora { get; set; } = new TimeOnly(22, 0, 0);






    }
}
