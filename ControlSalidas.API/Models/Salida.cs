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
        public List<Hospital> Hospital { get; set; } = new List<Hospital>();
        public List<SalidaFuncionario> Funcionarios { get; set; } = new List<SalidaFuncionario>();

    }// class
}// namespace
