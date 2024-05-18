using Microsoft.AspNetCore.Mvc;
using Postres.Funciones.Recetas;

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

        [HttpGet]
        public async Task<IActionResult> GetAllRecetas()
        {
            var result = await _recetasCommand.GetListRecetas();
            return new OkObjectResult(result);
        }
    }
}
