namespace WebAppPIA.Models
{
    public class paciente
    {
        public int id_paciente { get; set; }
        public string name_paciente { get; set; }
        public string email_paciente { get; set; }
        public string phone_paciente { get; set; }
        public string fechaNac_paciente { get; set; }
        public DateTime created_At { get; set; }
        public int id_ciudadPacFK { get; set; }
        public int id_contacto { get; set; }
        public int id_empleado { get; set; }
    }

    public class contactoEmerg
    {
        public int id_contacto { get; set; }
        public string name_contacto { get; set; }
        public string email_contacto { get; set; }
        public string phone_contacto { get; set; }
        public DateTime created_At { get; set; }
        public int id_ciudadContFK { get; set; }
    }
}
