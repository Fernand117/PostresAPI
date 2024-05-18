using Microsoft.OpenApi.Models;
using Postres.Domain;
using Postres.Funciones.Categorias;
using Postres.Funciones.Recetas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureHttpJsonOptions(c => c.SerializerOptions.IncludeFields = true);

builder.Services.AddDbContext<PostresDBContext>();

builder.Services.AddMvc();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Postres API",
        Version = "v1",
        Description = "Mapeo de los endpoints que componen esta API"
    });
});

builder.Services.AddScoped<ICategoriasCommand, CategoriasCommandHandler>();
builder.Services.AddScoped<IRecetasCommand, RecetasCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.MapSwagger();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Caduca REST");
    c.RoutePrefix = string.Empty;
});

app.Run();