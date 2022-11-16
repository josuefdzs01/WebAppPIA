namespace WebAppPIA.Models
{
    public class citaAgendar
    {
        public int id_consulta { get; set; }
        public int id_pacConsulta { get; set; }
        public int id_empConsulta { get; set; }
        public string fechaCita { get; set; }
        public string peso { get; set; }
        public string altura { get; set; }
        public string temperatura { get; set; }
        public string padecimiento { get; set; }
        public string medicamento { get; set; }
    }
        public class citaData
    {
        public int id_consulta { get; set; }
        public int id_pacConsulta { get; set; }
        public string name_paciente { get; set; }
        public string email_paciente { get; set; }
        public string phone_paciente { get; set; }
        public string fechaNac_paciente { get; set; }
        public int id_ciudadPaciente { get; set; }
        public string name_pacCiudad { get; set; }
        public int id_pacContacto { get; set; }
        public string name_pacContacto { get; set; }
        public string email_pacContacto { get; set; }
        public string phone_pacContacto { get; set; }
        public int id_ciudadContFK { get; set; }
        public string ciudad_cont { get; set; }
        public int id_empleado { get; set; }
        public string name_empleado { get; set; }
        public string email_empleado { get; set; }
        public string phone_empleado { get; set; }
        public int id_empTurno { get; set; }
        public string horario_emp { get; set; }
        public string horas_emp { get; set; }
        public int id_empPuesto { get; set; }
        public string name_empPuesto { get; set; }
        public string fechaCita { get; set; }
        public string peso { get; set; }
        public string altura { get; set; }
        public string temperatura { get; set; }
        public string padecimiento { get; set; }
        public string medicamento { get; set; }
        public int id_consul { get; set; }
        public string name_consul { get; set; }
        public string email_consul { get; set; }
        public string phone_consul { get; set; }
    }
}
