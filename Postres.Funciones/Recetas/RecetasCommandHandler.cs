using Postres.Domain;
using Postres.Domain.Recetas;
using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.Recetas
{
    public class RecetasCommandHandler : IRecetasCommand
    {
        private PostresDBContext _dbContext;

        public RecetasCommandHandler(PostresDBContext dBContext)
        {
            _dbContext = dBContext ?? throw new ArgumentException(nameof(_dbContext));
        }

        public Task<ResultAPI> ActualizarReceta(RecetasCommandHandlerValidator validator, string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> EliminarCategoria(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> GetListRecetas()
        {
            throw new NotImplementedException();
        }

        public Task<ResultAPI> GetRecetaByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultAPI> GuardarReceta(RecetasCommandHandlerValidator validator)
        {
            var receta = new Receta() 
            {
                Id = new Guid(),
                Titulo = validator.Titulo,
                Descripcion = validator.Descripcion,
                Cuerpo = validator.Cuerpo,
                Etiquetas = validator.Etiquetas,
                IdAutor = validator.IdAutor,
                IdCategoria = validator.IdCategoria
            };

            await _dbContext.AddAsync(receta);
            await _dbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Receta {validator.Titulo} guardada correctamente.");
        }
    }
}
