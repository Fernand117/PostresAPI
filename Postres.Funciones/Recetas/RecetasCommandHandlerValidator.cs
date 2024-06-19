using Newtonsoft.Json;

namespace Postres.Funciones.Recetas
{
    public class RecetasCommandHandlerValidator
    {
        [JsonProperty("Titulo")]
        public string Titulo {  get; set; }
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty("Cuerpo")]
        public string Cuerpo { get; set; }
        [JsonProperty("Etiquetas")]
        public string Etiquetas { get; set; }

        [JsonProperty("IdAutor")]
        public Guid IdAutor {  get; set; }
        [JsonProperty("IdCategoria")]
        public Guid IdCategoria { get; set; }
        
        [JsonConstructor]
        public RecetasCommandHandlerValidator(string titulo, string descripcion, string cuerpo, string etiquetas, Guid idAutor, Guid idCategoria)
        {
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Cuerpo = cuerpo;
            this.Etiquetas = etiquetas;

            this.IdAutor = idAutor;
            this.IdCategoria = idCategoria;
        }
    }
}
