using Microsoft.EntityFrameworkCore;
using Postres.Domain;
using Postres.Domain.Usuarios;
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

            if (allData.Count == 0) return ResultAPI.Ok("No existe ning�n registro de este usuario");

            return ResultAPI.Ok(allData, "Detalles del usuario");
        }

        public async Task<ResultAPI> GetDataUserByName(string usuario)
        {
            var dataUser = await _postresDBContext.DatosUsuarios.Where(d => d.Nombre == usuario).FirstOrDefaultAsync();

            if (dataUser == null) return ResultAPI.Ok("No existe1 el perfil del usuario.");

            return ResultAPI.Ok(dataUser, "Detalles del usuario.");
        }

        public async Task<ResultAPI> SaveData(DatosUsuariosCommandHandlerValidator datosValidator)
        {
            DatosUsuario dtUsuario = new DatosUsuario() 
            {
                Id = Guid.NewGuid(),
                IdUsuario = datosValidator.IdUsuario,
                Nombre = datosValidator.Nombre,
                Paterno = datosValidator.Paterno,
                Materno = datosValidator.Materno,
                FechaNacimiento = datosValidator.FechaNacimiento,
                FotoPerfil = datosValidator.FotoPerfil,
                FotoPortada = datosValidator.FotoPortada
            };

            await _postresDBContext.AddAsync(dtUsuario);
            await _postresDBContext.SaveChangesAsync();

            return ResultAPI.Ok(dtUsuario, "Detalles del perfil de usuario guardado correctamente");
        }

        public Task<ResultAPI> UpdatDataUser(DatosUsuariosCommandHandlerValidator datosValidator, string usuario)
        {
            throw new NotImplementedException();
        }
    }
}
