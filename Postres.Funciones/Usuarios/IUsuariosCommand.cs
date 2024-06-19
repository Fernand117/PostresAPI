using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.Usuarios
{
    public interface IUsuariosCommand
    {
        Task<ResultAPI> GetAllUsers();
        Task<ResultAPI> GetUsersByName(string usuario);
        Task<ResultAPI> Login(UsuariosCommandHandlerValidator usuario);
        Task<ResultAPI> SaveUsuario(UsuariosCommandHandlerValidator usuario);
        Task<ResultAPI> UpdateUsuario(UsuariosCommandHandlerValidator usuario, string nombre);
        Task<ResultAPI> DeleteUsuario(string usuario);
    }
}
