using Newtonsoft.Json;

namespace Postres.Funciones.Usuarios
{
    public class UsuariosCommandHandlerValidator
    {
        [JsonProperty("NombreUsuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        [JsonProperty("Email")]
        public string Email { get; set; } = string.Empty;
        [JsonProperty("Clave")]
        public string Password { get; set; } = string.Empty;

        [JsonConstructor]
        public UsuariosCommandHandlerValidator(string us, string em, string pasw)
        {
            NombreUsuario = us;
            Email = em;
            Password = pasw;
        }
    }
}
