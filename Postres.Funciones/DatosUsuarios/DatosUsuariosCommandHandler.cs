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

        public async Task<ResultAPI> DeleteDataUser(string usuario)
        {
            var getUsuario = await _postresDBContext.DatosUsuarios.Where(d => d.Nombre == usuario).FirstOrDefaultAsync();

            _postresDBContext.Remove(getUsuario);
            await _postresDBContext.SaveChangesAsync();

            return ResultAPI.Ok($"Detalles del usuario {usuario} eliminados");
        }

        public async Task<ResultAPI> GetAllDataUsers()
        {
            var allData = await _postresDBContext.DatosUsuarios.ToListAsync();

            if (allData.Count == 0) return ResultAPI.Ok("No existe ningún registro de este usuario");

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

        public async Task<ResultAPI> UpdatDataUser(DatosUsuariosCommandHandlerValidator datosValidator, string usuario)
        {
            var getUsuario = await _postresDBContext.DatosUsuarios.Where(d => d.Nombre == usuario).FirstOrDefaultAsync();

            getUsuario.Nombre = datosValidator.Nombre;
            getUsuario.Paterno = datosValidator.Paterno;
            getUsuario.Materno = datosValidator.Materno;
            getUsuario.FechaNacimiento = datosValidator.FechaNacimiento;
            getUsuario.FotoPerfil = datosValidator.FotoPerfil;
            getUsuario.FotoPortada = datosValidator.FotoPortada;

            _postresDBContext.Update(getUsuario);
            await _postresDBContext.SaveChangesAsync();

            return ResultAPI.Ok("Detalles del usuario actualizados correctamente")
        }
    }
}
