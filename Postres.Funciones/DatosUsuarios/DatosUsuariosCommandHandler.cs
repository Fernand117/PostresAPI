using Microsoft.EntityFrameworkCore;
using Postres.Domain;
using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.DatosUsuarios
{
    public class DatosUsuariosCommandHandler : IDatosUsuariosCommand
    {
        private readonly PostresDBContext _postresDBContext;

        public DatosUsuariosCommandHandler(PostresDBContext postresDBContext)
        {
            _postresDBContext = postresDBContext ?? throw new ArgumentException(nameof(postresDBContext));
        }

        public Task<ResultAPI> DeleteDataUser(string usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultAPI> GetAllDataUsers()
        {
            var allData = await _postresDBContext.DatosUsuarios.ToListAsync();

            if (allData.Count == 0) return ResultAPI.Ok("No existe ningún registro de este usuario");

            return ResultAPI.Ok(allData, "Detalles del usuario");
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
