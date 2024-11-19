var builder = WebApplication.CreateBuilder(args);

// Agregar los servicios a la colección de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // Asegúrate de usar la URL de tu frontend
              .AllowAnyMethod()                   // Permite todos los métodos (GET, POST, etc.)
              .AllowAnyHeader()                   // Permite cualquier cabecera
              .AllowCredentials();                // Permite el uso de credenciales (cookies, autenticación)
    });
});

var app = builder.Build();

// Configurar el pipeline de la solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();