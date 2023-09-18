
using Application.Interfaces;
using Application.UseCase.Pacientes;
using Domain;
using Infraestructure;
using Infraestructure.Command;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TEAyudo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//     CUSTOM

builder.Services.AddDbContext<TEAyudoContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=TEAyudo;Trusted_Connection=True;TrustServerCertificate=True");

});




//     CUSTOM
//cuando me piden un IServiceGetAll devuelve una clase ServiceGetAll, inyeccion de dependencia 
//builder.Services.AddTransient<IServiceGetAll, ServiceGetAll>(); elimine sus clase, pero lo dejo a modo de ejemplo
builder.Services.AddTransient<IPacienteService, PacienteService>();
builder.Services.AddTransient<IPacientesCommand, PacientesCommand>();
builder.Services.AddTransient<IPacientesQuerys, PacientesQuerys>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
