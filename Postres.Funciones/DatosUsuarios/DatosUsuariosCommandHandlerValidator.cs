using Newtonsoft.Json;

namespace Postres.Funciones.DatosUsuarios
{
    public class DatosUsuariosCommandHandlerValidator
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        [JsonProperty("Paterno")]
        public string Paterno {  get; set; } = string.Empty;
        [JsonProperty("Materno")]
        public string Materno {  get; set; } = string.Empty;
        [JsonProperty("FotoPerfil")]
        public string FotoPerfil { get; set; } = string.Empty;
        [JsonProperty("FotoPortada")]
        public string FotoPortada {  get; set; } = string.Empty;
        [JsonProperty("IDUsuario")]
        public Guid IdUsuario { get; set; }
        [JsonProperty("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
