using System.ComponentModel.DataAnnotations;

namespace Postres.Domain.Categorias;

public class Categoria
{
    public Guid Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string UrlFoto { get; set; }
}