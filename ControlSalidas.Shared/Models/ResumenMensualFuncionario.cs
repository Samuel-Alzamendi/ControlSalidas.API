using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class ResumenMensualFuncionario
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; } = null!;
        public int Anio { get; set; }
        public int Mes { get; set; }
        public double HorasNormales { get; set; }
        public double HorasExtra { get; set; }
        public int CantidadSalidas { get; set; }
        public int DiasFuera { get; set; }
        public int Noches { get; set; }
        public decimal ImportePernoctes { get; set; }
        public decimal Viaticos { get; set; }
        public decimal ImporteTotal { get; set; }
    }
}
