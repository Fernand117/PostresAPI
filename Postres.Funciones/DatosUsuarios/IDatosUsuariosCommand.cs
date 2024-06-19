using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.DatosUsuarios
{
    public interface IDatosUsuariosCommand
    {
        Task<ResultAPI> GetAllDataUsers();
        Task<ResultAPI> GetDataUserByName(string usuario);
        Task<ResultAPI> SaveData(DatosUsuariosCommandHandlerValidator datosValidator);
        Task<ResultAPI> UpdatDataUser(DatosUsuariosCommandHandlerValidator datosValidator, string usuario);
        Task<ResultAPI> DeleteDataUser(string usuario);
    }
}
