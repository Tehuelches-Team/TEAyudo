
using Application.Interfaces;
using Application.Interfaces.Aplication;
using Application.UseCase.Filtros;
using Domain;
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
    options.UseSqlServer("Server=localhost;Database=TEAyudo;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=true");

});


builder.Services.AddTransient<IFiltroAcompanante, FiltroAcompanante>(); //Inyecciones de dependencias para los 
builder.Services.AddTransient<IConsulta, Query_Acompanante>();          //gets de acompananteDTO


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
