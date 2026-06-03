namespace ControlSalidas.Web.Models
{
    public class Funcionario
    {

        public int id { get; set; }
        public string ci { get; set; } = "";
        public string nombre { get; set; } = "";
        public string cargo { get; set; } = "";
        public int noches { get; set; }
        public int cantidadSalidas { get; set; }
        public int diasFuera { get; set; }


    }
}
