using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Postres.Domain.Usuarios;
using Postres.Funciones.DatosUsuarios;

namespace Postres.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosUsuariosController : ControllerBase
    {
        private readonly IDatosUsuariosCommand _usuariosCommand;

        public DatosUsuariosController(IDatosUsuariosCommand usuariosCommand)
        {
            _usuariosCommand = usuariosCommand ?? throw new ArgumentException(nameof(usuariosCommand));
        }

        private DatosUsuariosCommandHandlerValidator Validator(DatosUsuario datos)
        {
            var serReq = JsonConvert.SerializeObject(datos);
            var validator = JsonConvert.DeserializeObject<DatosUsuariosCommandHandlerValidator>(serReq);
            return validator!;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usuariosCommand.GetAllDataUsers();
            return new OkObjectResult(result);
        }

        [HttpGet("detalles/{usuario}")]
        public async Task<IActionResult> GetDetailsUser(string usuario)
        {
            var result = await _usuariosCommand.GetDataUserByName(usuario);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserDetails([FromBody] DatosUsuario datos)
        {
            var validator = Validator(datos);
            var result = await _usuariosCommand.SaveData(validator);
            return new OkObjectResult(result);
        }
    }
}
