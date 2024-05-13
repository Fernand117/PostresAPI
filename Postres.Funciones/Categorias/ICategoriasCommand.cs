using Postres.Domain.Categorias;
using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.Categorias
{
    public interface ICategoriasCommand
    {
        Task<ResultAPI> GetListCategorias();
        Task<ResultAPI> GetCategoriaById(string nombre);
        Task<ResultAPI> GuardarCategoria(CategoriasCommandHandlerValidator categoria);
        Task<ResultAPI> ActualizarCategoria(CategoriasCommandHandlerValidator categoria);
        Task<ResultAPI> EliminarCategoria(string nombre);
    }
}
