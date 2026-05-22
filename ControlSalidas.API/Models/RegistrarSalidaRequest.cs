namespace ControlSalidas.API.Models
{
    public class RegistrarSalidaRequest
    {

        public int funcionarioId { get; set; }
        public DateOnly fechaSalida { get; set; }
        public DateOnly fechaLlegada { get; set; }
        public Hospital hospital { get; set; }


    }// class

}// namespace
