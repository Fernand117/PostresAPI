using Postres.Domain.Categorias;
using Postres.Domain.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace Postres.Domain.Recetas
{
    public class Receta
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;
        public string Etiquetas { get; set; } = string.Empty;
        public Guid IdAutor { get; set; }
        public Guid IdCategoria { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
