namespace ControlSalidas.Web.Models
{
    public class Salida
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateOnly FechaSalida { get; set; }
        public DateOnly FechaLlegada { get; set; }
        public int Dias { get; set; }
        public int Noches { get; set; }
        public int SalidasCalculadas { get; set; }
        public string Estado { get; set; } = "";
        // hay q crear el modelo hospital en Models
        //public List<Hospital> Hospital { get; set; } = new List<Hospital>();
        public List<int> IdFuncionarios { get; set; } = new List<int>();


    }
}
