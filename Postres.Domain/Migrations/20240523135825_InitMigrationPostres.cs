using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postres.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrationPostres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreCategoria = table.Column<string>(type: "text", nullable: false),
                    URLFoto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdCategoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreUsuario = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdUsuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "DatosUsuarios",
                columns: table => new
                {
                    IdDatosUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Paterno = table.Column<string>(type: "text", nullable: false),
                    Materno = table.Column<string>(type: "text", nullable: false),
                    FotoPerfil = table.Column<string>(type: "text", nullable: false),
                    FotoPortada = table.Column<string>(type: "text", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdDatosUsuario", x => x.IdDatosUsuario);
                    table.ForeignKey(
                        name: "FK_tbDatosUsuario_tbUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    IdReceta = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cuerpo = table.Column<string>(type: "text", nullable: false),
                    Etiquetas = table.Column<string>(type: "text", nullable: false),
                    IdAutor = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCategoria = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioNavigationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdReceta", x => x.IdReceta);
                    table.ForeignKey(
                        name: "FK_Recetas_Usuarios_IdUsuarioNavigationId",
                        column: x => x.IdUsuarioNavigationId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_tbRecetas_tbCategorias",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosUsuarios_IdUsuario",
                table: "DatosUsuarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_IdCategoria",
                table: "Recetas",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_IdUsuarioNavigationId",
                table: "Recetas",
                column: "IdUsuarioNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosUsuarios");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
