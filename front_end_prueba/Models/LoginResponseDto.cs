namespace front_end_prueba.Models
{
    public class LoginResponseDto
    {
        public RespuestaDto? Respuesta { get; set; }
        public ResultadoDto? Resultado { get; set; }
    }

    public class RespuestaDto
    {
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public bool EsExitosa { get; set; }
        public bool ExisteExcepcion { get; set; }
    }

    public class ResultadoDto
    {
        public bool ValidarFactorAutenticacion { get; set; }
        public JwtDto? Jwt { get; set; }
    }

    public class JwtDto
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? Expiration { get; set; }
    }
}
