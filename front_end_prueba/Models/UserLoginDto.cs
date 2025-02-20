namespace front_end_prueba.Models
{
    public class UserLoginDto
    {
        public string ?Usuario { get; set; }
        public string ?Clave { get; set; }
        public bool RecordarSesion { get; set; }
    }
}
