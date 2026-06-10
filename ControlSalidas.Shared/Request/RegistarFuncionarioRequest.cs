namespace ControlSalidas.Shared.Request
{
    public class RegistarFuncionarioRequest
    {
        public string Ci { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Cargo { get; set; } = "";
        public TimeOnly HorarioLaboralEntrada { get; set; } = new TimeOnly(7, 0, 0);
        public TimeOnly HorarioLaboralSalida { get; set; } = new TimeOnly(13, 0, 0);

    }
}
