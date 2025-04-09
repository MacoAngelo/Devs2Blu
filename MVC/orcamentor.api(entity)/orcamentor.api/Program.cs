using Microsoft.EntityFrameworkCore;
using orcamentor.api.Infra.Data;
using orcamentor.api.Model.Repository;
using orcamentor.api.Model.Repository.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

//Banco 

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var carruxConnectionString = builder.Configuration.GetConnectionString("CarruxConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AppCarruxDbContext>(options => 
                options.UseMySql(carruxConnectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
    );

//builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
options.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
