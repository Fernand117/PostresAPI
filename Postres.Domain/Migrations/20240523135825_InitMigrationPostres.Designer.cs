﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Postres.Domain;

#nullable disable

namespace Postres.Domain.Migrations
{
    [DbContext(typeof(PostresDBContext))]
    [Migration("20240523135825_InitMigrationPostres")]
    partial class InitMigrationPostres
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Postres.Domain.Categorias.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdCategoria");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NombreCategoria");

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("URLFoto");

                    b.HasKey("Id")
                        .HasName("PK_IdCategoria");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("Postres.Domain.Recetas.Receta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdReceta");

                    b.Property<string>("Cuerpo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Cuerpo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("Etiquetas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdAutor")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdCategoria")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdUsuarioNavigationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Titulo");

                    b.HasKey("Id")
                        .HasName("PK_IdReceta");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdUsuarioNavigationId");

                    b.ToTable("Recetas", (string)null);
                });

            modelBuilder.Entity("Postres.Domain.Usuarios.DatosUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdDatosUsuario");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FotoPortada")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Materno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Paterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_IdDatosUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("DatosUsuarios", (string)null);
                });

            modelBuilder.Entity("Postres.Domain.Usuarios.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_IdUsuario");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Postres.Domain.Recetas.Receta", b =>
                {
                    b.HasOne("Postres.Domain.Categorias.Categoria", "IdCategoriaNavigation")
                        .WithMany("RecetasEntity")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tbRecetas_tbCategorias");

                    b.HasOne("Postres.Domain.Usuarios.Usuario", "IdUsuarioNavigation")
                        .WithMany()
                        .HasForeignKey("IdUsuarioNavigationId");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Postres.Domain.Usuarios.DatosUsuario", b =>
                {
                    b.HasOne("Postres.Domain.Usuarios.Usuario", "IdUsuarioNavigation")
                        .WithMany("DatosUsuarioEntity")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tbDatosUsuario_tbUsuario");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Postres.Domain.Categorias.Categoria", b =>
                {
                    b.Navigation("RecetasEntity");
                });

            modelBuilder.Entity("Postres.Domain.Usuarios.Usuario", b =>
                {
                    b.Navigation("DatosUsuarioEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
