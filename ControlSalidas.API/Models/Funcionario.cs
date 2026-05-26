namespace ControlSalidas.API.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public int Ci {  get; set; }
        public string Nombre { get; set; } = "";
        public string Cargo { get; set; } = "";
        public int Noches { get; set; } = 0;
        public int CantidadSalidas { get; set; } = 0;
        public int DiasFuera { get; set; } = 0;

    }// class
}// namespace
