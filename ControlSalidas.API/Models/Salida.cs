namespace ControlSalidas.API.Models
{
    public class Salida
    {
        public int id { get; set; }
        public DateOnly fechaSalida { get; set; }
        public DateOnly fechaLlegada { get; set; }
        public int dias { get; set; }
        public int noches { get; set; }
        public int salidasCalculadas { get; set; }
        public List<Hospital> hospital { get; set; }
        public List<SalidaFuncionario> Funcionarios { get; set; }

    }// class
}// namespace
