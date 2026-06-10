using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class Salida
    {
        public int Id { get; set; }
        public DateOnly FechaSalida { get; set; }
        public DateOnly FechaLlegada { get; set; }
        public int Dias { get; set; }
        public int Noches { get; set; }
        public int SalidasCalculadas { get; set; }
        public string Estado { get; set; } = "";
        public List<int> HospitalesIds { get; set; } = new List<int>();
        public List<int> IdFuncionarios { get; set; } = new List<int>();

    }
}
