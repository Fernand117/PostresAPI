namespace Postres.Domain.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string FotoPerfil { get; set; } = string.Empty;
        public string FotoPortada { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
