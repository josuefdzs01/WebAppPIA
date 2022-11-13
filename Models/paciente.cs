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

    public class DataPacFull
    {
        public int id_paciente { get; set; }
        public string nombre_pac { get; set; }
        public string email_pac { get; set; }
        public string phone_pac { get; set; }
        public string fechaNac_pac { get; set; }
        public string dado_alta { get; set; }
        public int id_ciudad { get; set; }
        public string name_city { get; set; }
        public int id_contacto { get; set; }
        public string name_cont { get; set; }
        public string email_cont { get; set; }
        public string phone_cont { get; set; }
        public string dado_altaCont { get; set; }
        public int id_ciudadCont { get; set; }
        public string name_cityCont { get; set; }
        public int id_emp { get; set; }
    }
}
