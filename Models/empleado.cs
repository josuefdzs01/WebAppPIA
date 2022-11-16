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

    public class empleadosMostrar
    {
        public int id_empleado { get; set; }
        public string nombre_emp { get; set; }
        public string email_emp { get; set; }
        public string phone_emp { get; set; }
        public DateTime dado_alta { get; set; }
        public string contraseña { get; set; }
        public int id_ciudadEmp { get; set; }
        public string nombre_city { get; set; }
        public int id_turno { get; set; }
        public string name_horario { get; set; }
        public string horas { get; set; }
        public int id_puesto { get; set; }
        public string name_puesto { get; set; }
        public int id_consul { get; set; }
    }

    public class doctores
    {
        public int id_empleado { get; set; }
        public string nombre_emp { get; set; }
        public int id_turno { get; set; }
        public string name_horario { get; set; }
        public string horas { get; set; }
        public int id_puesto { get; set; }
        public string name_puesto { get; set; }
    }
}
