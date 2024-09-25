var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Agrega Swagger

// Agregar servicios personalizados
builder.Services.AddSingleton<GestionInventario.Repositories.UsuarioRepositorio>();
builder.Services.AddSingleton<GestionInventario.Services.UsuarioServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Usa Swagger en desarrollo
    app.UseSwaggerUI(); // Interfaz de usuario de Swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


