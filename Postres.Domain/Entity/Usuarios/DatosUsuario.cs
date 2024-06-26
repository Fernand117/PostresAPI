﻿using System.ComponentModel.DataAnnotations;

namespace Postres.Domain.Usuarios
{
    public class DatosUsuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string FotoPerfil { get; set; } = string.Empty;
        public string FotoPortada { get; set; } = string.Empty;
        public Guid IdUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
