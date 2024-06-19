namespace Postres.Domain.DTO
{
    public class RecetaDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;
        public string Etiquetas { get; set; } = string.Empty;
        public string Categoria {  get; set; } = string.Empty;
        public string Autor {  get; set; } = string.Empty;
    }
}
