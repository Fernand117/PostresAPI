using Microsoft.EntityFrameworkCore;
using Postres.Domain;
using Postres.Domain.Categorias;
using Postres.Infraestructura.APIServices;

namespace Postres.Funciones.Categorias
{
    public class CategoriasCommandHandler : ICategoriasCommand
    {
        private PostresDBContext _dbContext;

        public CategoriasCommandHandler(PostresDBContext postresDBContext)
        {
            _dbContext = postresDBContext ?? throw new ArgumentException(nameof(_dbContext));
        }

        public Task<ResultAPI> ActualizarCategoria(CategoriasCommandHandlerValidator categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultAPI> EliminarCategoria(string nombre)
        {
            var categoria = await _dbContext.Categorias.Where(c => c.Nombre == nombre).FirstOrDefaultAsync();
            _dbContext.Remove(categoria);
            await _dbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Categoria {nombre} eliminada de la db.");
        }

        public async Task<ResultAPI> GetCategoriaById(string nombre)
        {
            var categoria = await _dbContext.Categorias.Where(c => c.Nombre == nombre).FirstOrDefaultAsync();

            if (categoria == null) return ResultAPI.Ok($"Lo sentimos, no existe ninguna categoria con el nombre {nombre}");

            return ResultAPI.Ok(categoria, "Categoria encontrada");
        }

        public async Task<ResultAPI> GetListCategorias()
        {
            var listaCategorias = await _dbContext.Categorias.ToListAsync();

            if (listaCategorias.Count == 0) return ResultAPI.Ok("No existe ninguna categoría registrada.");

            return ResultAPI.Ok(listaCategorias, "Lista de categorias cargada.");
        }

        public async Task<ResultAPI> GuardarCategoria(CategoriasCommandHandlerValidator categoriaSv)
        {
            var catsv = new Categoria()
            {
                Id = new Guid(),
                Nombre = categoriaSv.Nombre,
                UrlFoto = categoriaSv.UrlFoto
            };

            await _dbContext.AddAsync(catsv);
            await _dbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Categoria {categoriaSv.Nombre} guardada correctamente");
        }
    }
}
