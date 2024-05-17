using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.Recetas
{
    public interface IRecetasCommand
    {
        Task<ResultAPI> GetListRecetas();
        Task<ResultAPI> GetRecetaByName(string name);
        Task<ResultAPI> GuardarReceta(RecetasCommandHandlerValidator validator);
        Task<ResultAPI> ActualizarReceta(RecetasCommandHandlerValidator validator, string nombre);
        Task<ResultAPI> EliminarReceta(string nombre);
    }
}
