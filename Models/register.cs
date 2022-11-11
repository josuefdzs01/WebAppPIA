namespace WebAppPIA.Models
{
    public class register
    {
        public string name_consul { get; set; }
        public string email_consul { get; set; }
        public string phone_consul { get; set; }
        public string password_consul { get; set; }
        public string id_ciudadFK  { get; set; }

        public static implicit operator register(string v)
        {
            throw new NotImplementedException();
        }
    }
}
