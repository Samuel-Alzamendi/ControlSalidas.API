namespace ControlSalidas.API.Models
{
    public class SalidaFuncionario
    {
        public int id { get; set; }
        public int salidaId { get; set; }
        public Salida salida { get; set; }
        public Funcionario funcionario { get; set; }

    }
}
