using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Postres.Funciones.Recetas;
using Postres.Domain.Recetas;

namespace Postres.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetasCommand _recetasCommand;

        public RecetasController(IRecetasCommand recetasCommand)
        {
            _recetasCommand = recetasCommand ?? throw new ArgumentException(nameof(recetasCommand));
        }

        private RecetasCommandHandlerValidator Validator(Receta receta)
        {
            var serReq = JsonConvert.SerializeObject(receta);
            var validator = JsonConvert.DeserializeObject<RecetasCommandHandlerValidator>(serReq);
            return validator!;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecetas()
        {
            var result = await _recetasCommand.GetListRecetas();
            return new OkObjectResult(result);
        }

        [HttpGet("lista/recetas")]
        public async Task<IActionResult> GetAllRecetasWithCategoriaAutor()
        {
            var result = await _recetasCommand.GetRecetaWithCategoria();
            return new OkObjectResult(result);
        }
        
        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _recetasCommand.GetRecetaByName(name);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRecetas([FromBody] Receta receta)
        {
            var validator = Validator(receta);
            var result = await _recetasCommand.GuardarReceta(validator);
            return new OkObjectResult(result);
        }

        [HttpPut("nombre/{nombre}")]
        public async Task<IActionResult> UpdateReceta([FromBody] Receta receta, string nombre)
        {
            var validator = Validator(receta);
            var result = await _recetasCommand.ActualizarReceta(validator, nombre);
            return new OkObjectResult(result);
        }

        [HttpDelete("nombre/{nombre}")]
        public async Task<IActionResult> DeleteReceta(string nombre)
        {
            var result = await _recetasCommand.EliminarReceta(nombre);
            return new OkObjectResult(result);
        }
    }
}
