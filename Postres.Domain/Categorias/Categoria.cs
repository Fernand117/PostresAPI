using System.ComponentModel.DataAnnotations;
using Postres.Domain.Recetas;

namespace Postres.Domain.Categorias;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string UrlFoto { get; set; } = string.Empty;

    public virtual ICollection<Receta>? RecetasEntity { get; set; }
}