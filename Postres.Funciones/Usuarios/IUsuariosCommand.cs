using Postres.Infraestructura.APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
