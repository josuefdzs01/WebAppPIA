namespace WebAppPIA.Models
{
    public class empleados
    {
        public int id_empleado { get; set; }
        public string name_empleado { get; set; }
        public string email_empleado { get; set; }
        public string phone_empleado { get; set; }
        public DateTime created_at { get; set; }
        public string password_empleado { get; set; }
        public int id_ciudadEmpFK { get; set; }
        public int id_turno { get; set; }
        public int id_puesto { get; set; }
        public int id_consul { get; set; }
    }
}
