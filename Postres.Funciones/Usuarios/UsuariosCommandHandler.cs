﻿using Microsoft.EntityFrameworkCore;
using Postres.Domain;
using Postres.Domain.DTO;
using Postres.Domain.Usuarios;
using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.Usuarios
{
    public class UsuariosCommandHandler : IUsuariosCommand
    {
        private readonly PostresDBContext _postresDbContext;

        public UsuariosCommandHandler(PostresDBContext context)
        {
            _postresDbContext = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<ResultAPI> DeleteUsuario(string usuario)
        {
            var usuarioDel = await _postresDbContext.Usuarios.Where(u => u.NombreUsuario == usuario).FirstOrDefaultAsync();

            if (usuarioDel == null) return ResultAPI.Ok($"El usuario {usuario} no existe");

            _postresDbContext.Remove(usuarioDel);
            await _postresDbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Usuario {usuario} eliminado.");
        }

        public async Task<ResultAPI> GetAllUsers()
        {
            var usuarios = await _postresDbContext.Usuarios.ToListAsync();

            if (usuarios == null) return ResultAPI.Ok("No hay ningún usuario registrado.");

            return ResultAPI.Ok(usuarios, "Lista de usuarios.");
        }

        public async Task<ResultAPI> GetUsersByName(string usuario)
        {
            var usuarioCon = await _postresDbContext.Usuarios.Where(u => u.NombreUsuario == usuario).FirstOrDefaultAsync();
            return ResultAPI.Ok(usuarioCon, "Lista de usuarios.");
        }

        public async Task<ResultAPI> Login(UsuariosCommandHandlerValidator usuario)
        {
            var usuarioLog = await _postresDbContext.Usuarios.Where(u => u.NombreUsuario == usuario.NombreUsuario && u.Password == usuario.Password).FirstOrDefaultAsync();

            if (usuarioLog == null) return ResultAPI.Ok("Usuario o contraseña incorrectos");

            var datosUsuario = await _postresDbContext.DatosUsuarios.Where(u => u.IdUsuario == usuarioLog.Id).FirstOrDefaultAsync();

            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                NombreUsuario = usuarioLog.NombreUsuario,
                Correo = usuarioLog.Correo,
                Password = usuarioLog.Password,
                Nombre = datosUsuario!.Nombre ?? "N/A",
                Paterno = datosUsuario!.Paterno ?? "N/A",
                Materno = datosUsuario!.Materno ?? "N/A",
                FotoPerfil = datosUsuario!.FotoPerfil ?? "N/A",
                FotoPortada = datosUsuario!.FotoPortada ?? "N/A",
                FechaNacimiento = datosUsuario!.FechaNacimiento,
                IdUsuario = usuarioLog.Id,
                Id = datosUsuario!.Id
            };

            return ResultAPI.Ok(usuarioDTO, "Usuario autenticado.");
        }

        public async Task<ResultAPI> SaveUsuario(UsuariosCommandHandlerValidator usuario)
        {
            Usuario usuarioSave = new Usuario()
            {
                Id = new Guid(),
                NombreUsuario = usuario.NombreUsuario,
                Password = usuario.Password,
                Correo = usuario.Email
            };

            await _postresDbContext.AddAsync(usuarioSave);
            await _postresDbContext.SaveChangesAsync();

            return ResultAPI.Ok("Usuario registrado correctamente.");
        }

        public async Task<ResultAPI> UpdateUsuario(UsuariosCommandHandlerValidator usuario, string nombre)
        {
            var usuarioCons = await _postresDbContext.Usuarios.Where(u => u.NombreUsuario == nombre).FirstOrDefaultAsync();

            if (usuarioCons == null) return ResultAPI.Ok($"No existe el usuario {nombre}");

            usuarioCons.NombreUsuario = usuario.NombreUsuario;
            usuarioCons.Correo = usuario.Email;
            usuarioCons.Password = usuario.Password;

            _postresDbContext.Update(usuarioCons);
            await _postresDbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Usuario actualizado {nombre}");
        }
    }
}
