namespace Postres.Domain.Usuarios;

public class Usuario
{
    public Guid Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICollection<DatosUsuario>? DatosUsuarioEntity { get; set; }
}