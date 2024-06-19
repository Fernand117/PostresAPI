using Newtonsoft.Json;

namespace Postres.Funciones.Categorias
{
    public class CategoriasCommandHandlerValidator
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [JsonProperty("UrlFoto")]
        public string UrlFoto { get; set; }

        [JsonConstructor]
        public CategoriasCommandHandlerValidator(string nombre, string foto)
        {
            Nombre = nombre;
            UrlFoto = foto;
        }
    }
}
