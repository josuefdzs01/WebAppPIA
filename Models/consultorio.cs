namespace WebAppPIA.Models
{
    public class consultorio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime Dado_Alta { get; set; }
        public string Contraseña { get; set; }

        public int ID_Ciudad { get; set; }
        public string Ciudad { get; set; }
    }
}
