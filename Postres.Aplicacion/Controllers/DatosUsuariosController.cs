using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Postres.Domain.Usuarios;
using Postres.Funciones.Usuarios;

namespace Postres.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosUsuariosController : ControllerBase
    {
        private readonly IUsuariosCommand _usuariosCommand;

        public DatosUsuariosController(IUsuariosCommand usuariosCommand)
        {
            _usuariosCommand = usuariosCommand ?? throw new ArgumentException(nameof(usuariosCommand));
        }
    }
}
