using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class SalidaFuncionario
    {
        public int Id { get; set; } = 0;
        public int SalidaId { get; set; } = 0;
        //public Salida Salida { get; set; } = new Salida();
        public int FuncionarioId { get; set; } = 0;
        //public Funcionario Funcionario { get; set; } = new Funcionario();
        public int Pernoctes { get; set; }
        public int Viaticos { get; set; }
        public decimal ImportePernoctes { get; set; }
    }
}
