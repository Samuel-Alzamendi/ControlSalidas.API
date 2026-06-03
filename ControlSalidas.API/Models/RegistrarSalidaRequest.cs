namespace ControlSalidas.API.Models
{
    public class RegistrarSalidaRequest
    {

        public List<int> FuncionariosIds { get; set; } = new List<int>();
        public DateOnly FechaSalida { get; set; } 
        public DateOnly FechaLlegada { get; set; }
        public List<int> HospitalId { get; set; } = new List<int>();


    }// class

}// namespace
