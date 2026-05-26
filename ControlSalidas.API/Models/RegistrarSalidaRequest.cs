namespace ControlSalidas.API.Models
{
    public class RegistrarSalidaRequest
    {

        public List<int> funcionariosIds { get; set; }
        public DateOnly fechaSalida { get; set; }
        public DateOnly fechaLlegada { get; set; }
        public List<int> hospitalId { get; set; }


    }// class

}// namespace
