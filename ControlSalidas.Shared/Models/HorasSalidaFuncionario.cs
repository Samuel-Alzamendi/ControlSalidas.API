using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSalidas.Shared.Models
{
    public class HorasSalidaFuncionario
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; } = null!;

        public int SalidaId { get; set; }
        public Salida Salida { get; set; } = null!;

        public double HorasNormales { get; set; }

        public double HorasExtra { get; set; }
    }
}
