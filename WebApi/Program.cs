using Aplication.UseCases;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Aplication.Mapping;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// --- 2. CADENA DE CONEXIÓN ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Infraestructure")));

// --- 3. AUTOMAPPER ---
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// --- 4. REPOSITORIOS (Inyeccion de Dependencias actualizada) ---
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IMedicamento, MedicamentoRepositorio>();
builder.Services.AddScoped<ObtenerMedicamentosVencidos>();
builder.Services.AddScoped<ObtenerBajoStock>();
// --- 5. CASOS DE USO (Actualizados) ---
builder.Services.AddScoped<CrearUsuario>();
builder.Services.AddScoped<CrearMedicamento>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
