using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Postres.Domain.Usuarios;
using Postres.Funciones.Usuarios;

namespace Postres.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosCommand _usuariosCommand;

        public UsuariosController(IUsuariosCommand usuariosCommand)
        {
            _usuariosCommand = usuariosCommand ?? throw new ArgumentException(nameof(usuariosCommand));
        }

        private UsuariosCommandHandlerValidator Validator(Usuario usuario)
        {
            var serReq = JsonConvert.SerializeObject(usuario);
            var validator = JsonConvert.DeserializeObject<UsuariosCommandHandlerValidator>(serReq);
            return validator!;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var validator = Validator(usuario);
            var result = await _usuariosCommand.Login(validator);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Usuario usuario)
        {
            var validator = Validator(usuario);
            var result = await _usuariosCommand.SaveUsuario(validator);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var result = await _usuariosCommand.GetAllUsers();
            return new OkObjectResult(result);
        }
    }
}
