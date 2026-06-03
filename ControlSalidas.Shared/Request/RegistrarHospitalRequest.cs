using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Request
{
    public class RegistrarHospitalRequest
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Departamento { get; set; } = "";
        public string Ciudad { get; set; } = "";


    }
}
