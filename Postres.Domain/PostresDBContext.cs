using Microsoft.EntityFrameworkCore;
using Postres.Domain.Categorias;
using Postres.Domain.Recetas;
using Postres.Domain.Usuarios;

namespace Postres.Domain;

public class PostresDBContext : DbContext
{
    #region DBSETs
    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Receta> Recetas { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<DatosUsuario> DatosUsuarios { get; set; }
    #endregion

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
            entity.Property(c => c.Id).HasColumnName("IdCategoria").ValueGeneratedOnAdd();

            entity.ToTable("Categorias");

            entity.Property(c => c.Nombre).HasColumnName("NombreCategoria");
            entity.Property(c => c.UrlFoto).HasColumnName("URLFoto");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(r => r.Id).HasName("PK_IdReceta");
            entity.Property(r => r.Id).HasColumnName("IdReceta").ValueGeneratedOnAdd();

            entity.ToTable("Recetas");

            entity.Property(r => r.Titulo).HasColumnName("Titulo");
            entity.Property(r => r.Descripcion).HasColumnName("Description");
            entity.Property(r => r.Cuerpo).HasColumnName("Cuerpo");
            entity.Property(r => r.Etiquetas);
            entity.Property(r => r.IdCategoria);
            entity.Property(r => r.IdAutor);

            entity.HasOne(r => r.IdCategoriaNavigation).WithMany(r => r.RecetasEntity)
                  .HasForeignKey(r => r.IdCategoria).HasConstraintName("FK_tbRecetas_tbCategorias");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.Id).HasName("PK_IdUsuario");
            entity.Property(u => u.Id).HasColumnName("IdUsuario").ValueGeneratedOnAdd();

            entity.ToTable("Usuarios");

            entity.Property(u => u.NombreUsuario);
            entity.Property(u => u.Correo);
            entity.Property(u => u.Password);
        });

        modelBuilder.Entity<DatosUsuario>(entity =>
        {
            entity.HasKey(u => u.Id).HasName("PK_IdDatosUsuario");
            entity.Property(u => u.Id).HasColumnName("IdDatosUsuario").ValueGeneratedOnAdd();

            entity.ToTable("DatosUsuarios");

            entity.Property(u => u.Nombre);
            entity.Property(u => u.Paterno);
            entity.Property(u => u.Materno);
            entity.Property(u => u.FotoPerfil);
            entity.Property(u => u.FotoPortada);
            entity.Property(u => u.FechaNacimiento);
            entity.Property(u => u.IdUsuario);

            entity.HasOne(u => u.IdUsuarioNavigation).WithMany(u => u.DatosUsuarioEntity)
                  .HasForeignKey(u => u.IdUsuario).HasConstraintName("FK_tbDatosUsuario_tbUsuario");
        });
    }
}