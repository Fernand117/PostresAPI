using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Postres.Domain.Categorias;
using Postres.Funciones.Categorias;

namespace Postres.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasCommand _categoriasCommand;

        public CategoriasController(ICategoriasCommand categoriasCommand)
        {
            _categoriasCommand = categoriasCommand ?? throw new ArgumentException(nameof(categoriasCommand));
        }

        private CategoriasCommandHandlerValidator Validator(Categoria categoria)
        {
            var serReq = JsonConvert.SerializeObject(categoria);
            var validator = JsonConvert.DeserializeObject<CategoriasCommandHandlerValidator>(serReq);
            return validator!;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoriasCommand.GetListCategorias();
            return new OkObjectResult(result);
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> GetCategoriaByName(string nombre)
        {
            var result = await _categoriasCommand.GetCategoriaById(nombre);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategoria([FromBody] Categoria request)
        {
            var validator = Validator(request);
            var result = await _categoriasCommand.GuardarCategoria(validator!);
            return new OkObjectResult(result);
        }

        [HttpPut("actualizar/{nombre}")]
        public async Task<IActionResult> UpdateCategoria([FromBody] Categoria request, string nombre)
        {
            var validator = Validator(request);
            var result = await _categoriasCommand.ActualizarCategoria(validator, nombre);
            return new OkObjectResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoria([FromBody] Categoria request)
        {
            var validator = Validator(request);
            var result = await _categoriasCommand.EliminarCategoria(validator!.Nombre);
            return new OkObjectResult(result);
        }
    }
}
