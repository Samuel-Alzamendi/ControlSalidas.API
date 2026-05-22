namespace ControlSalidas.API.Models
{
    public class Salida
    {
        public int id { get; set; }
        public int funcionarioId { get; set; }
        public DateOnly fechaSalida { get; set; }
        public DateOnly fechaLlegada { get; set; }
        public int dias { get; set; }
        public int noches { get; set; }
        public int salidasCalculadas { get; set; }
    

    
    }// class
}// namespace
