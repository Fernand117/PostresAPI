using Microsoft.EntityFrameworkCore;
using Postres.Domain;
using Postres.Domain.DTO;
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

        public async Task<ResultAPI> ActualizarReceta(RecetasCommandHandlerValidator validator, string nombre)
        {
            var receta = await _dbContext.Recetas.Where(r => r.Titulo == nombre).FirstOrDefaultAsync();

            if (receta == null) return ResultAPI.Ok($"No se encontró ninguna receta llamada {nombre}");

            receta.Titulo = validator.Titulo;
            receta.Descripcion = validator.Descripcion;
            receta.Cuerpo = validator.Cuerpo;
            receta.Etiquetas = validator.Etiquetas;
            receta.IdAutor = validator.IdAutor;
            receta.IdCategoria = validator.IdCategoria;
            
            _dbContext.Update(receta);
            await _dbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Receta {nombre} actualizada correctamente");
        }

        public async Task<ResultAPI> EliminarReceta(string nombre)
        {
            var receta = await _dbContext.Recetas.Where(r => r.Titulo == nombre).FirstOrDefaultAsync();

            if (receta == null) return ResultAPI.Ok($"No se encontró ninguna receta llamada {nombre}");

            _dbContext.Remove(receta);
            await _dbContext.SaveChangesAsync();

            return ResultAPI.Ok($"Receta {nombre} eliminada correctamente");
        }

        public async Task<ResultAPI> GetListRecetas()
        {
            var listaRecetas = await _dbContext.Recetas.ToListAsync();
            
            if (listaRecetas == null) return ResultAPI.Ok("No se encontró ninguna receta");
            
            return ResultAPI.Ok(listaRecetas, "Lista de recetas");
        }

        public async Task<ResultAPI> GetRecetaByName(string name)
        {
            var receta = await _dbContext.Recetas.Where(r => r.Titulo == name).FirstOrDefaultAsync();
            
            if (receta == null) return ResultAPI.Ok($"No se encontró ninguna receta {name}");

            return ResultAPI.Ok(receta, "Receta encontrada");
        }

        public async Task<ResultAPI> GetRecetaWithCategoria()
        {
            List<RecetaDTO> listaRecetasCategorias = new List<RecetaDTO>();
            var recetaAll = await _dbContext.Recetas.ToListAsync();

<<<<<<< HEAD
            if (recetaAll == null) return ResultAPI.Ok("No hay recetas");

=======
            if (recetaAll.Count == 0) return ResultAPI.Ok("No hay recetas aún.");
            
>>>>>>> master
            foreach (var recetaItem in recetaAll)
            {
                var categoriaCons = await _dbContext.Categorias.Where(c => c.Id == recetaItem.IdCategoria).FirstOrDefaultAsync();
                var autorConsulta = await _dbContext.DatosUsuarios.Where(u => u.Id == recetaItem.IdAutor).FirstOrDefaultAsync();
                listaRecetasCategorias.Add(new RecetaDTO()
                {
                    Titulo = recetaItem.Titulo,
                    Descripcion = recetaItem.Descripcion,
                    Cuerpo = recetaItem.Cuerpo,
                    Etiquetas = recetaItem.Etiquetas,
                    Categoria = categoriaCons!.Nombre,
                    Autor = autorConsulta!.Nombre + " " + autorConsulta!.Paterno
                });
            }

            return ResultAPI.Ok(listaRecetasCategorias, "Lista de recetas");
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
