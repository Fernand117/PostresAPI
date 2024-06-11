using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.DatosUsuarios
{
    public class DatosUsuariosCommandHandler : IDatosUsuariosCommand
    {
        public Task<ResultAPI> DeleteDataUser(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> GetAllDataUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> GetDataUserByName(string usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> SaveData(DatosUsuariosCommandHandlerValidator datosValidator)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> UpdatDataUser(DatosUsuariosCommandHandlerValidator datosValidator, string usuario)
        {
            throw new NotImplementedException();
        }
    }
}
