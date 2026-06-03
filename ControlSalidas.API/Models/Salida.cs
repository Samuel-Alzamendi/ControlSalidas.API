namespace ControlSalidas.API.Models
{
    public class Salida
    {
        public int Id { get; set; }
        public DateOnly FechaSalida { get; set; }
        public DateOnly FechaLlegada { get; set; }
        public int Dias { get; set; }
        public int Noches { get; set; }
        public int SalidasCalculadas { get; set; }
        public List<Hospital> Hospitales { get; set; } = new List<Hospital>();
        public List<int> IdFuncionarios { get; set; } = new List<int>();

    }// class
}// namespace
