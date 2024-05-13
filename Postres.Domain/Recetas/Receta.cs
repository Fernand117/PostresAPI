using Postres.Domain.Categorias;

namespace Postres.Domain.Recetas
{
    public class Receta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
