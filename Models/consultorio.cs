namespace WebAppPIA.Models
{
    public class consultorio
    {
        public int id_consul { get; set; }
        public string name_consul { get; set; }
        public string email_consul { get; set; }
        public string phone_consul { get; set; }
        public DateTime created_at { get; set; }
        public string password_consul { get; set; }

        public int id_ciudadFK { get; set; }
    }
}
