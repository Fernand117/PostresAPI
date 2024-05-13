using Microsoft.EntityFrameworkCore;
using Postres.Domain.Categorias;
using Postres.Domain.Recetas;

namespace Postres.Domain;

public class PostresDBContext : DbContext
{
    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Receta> Recetas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseNpgsql("host=localhost;port=5432;database=postresdb;username=postgres;password=Master117+");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(c => c.Id).HasName("PK_IdCategoria");
            entity.ToTable("Categorias");

            entity.Property(c => c.Nombre).HasColumnName("NombreCategoria");
            entity.Property(c => c.UrlFoto).HasColumnName("URLFoto");
        });
    }
}