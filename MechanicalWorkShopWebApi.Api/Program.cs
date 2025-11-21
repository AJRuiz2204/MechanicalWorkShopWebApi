using Mechanical_workshop.Services.Mappings;
using MechanicalWorkShopWebApi.Data;
using MechanicalWorkShopWebApi.Domain.Interfaces.IRepository;
using MechanicalWorkShopWebApi.Domain.Interfaces.IService;
using MechanicalWorkShopWebApi.Infrastructure.Repositories;
using MechanicalWorkShopWebApi.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar SQL Server
builder.Services.AddDbContext<WorkshopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Inyección de Dependencias (DI)
// Conectamos las Interfaces con sus Implementaciones
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// 3. Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();