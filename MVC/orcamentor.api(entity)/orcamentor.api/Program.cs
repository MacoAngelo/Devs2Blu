using Microsoft.EntityFrameworkCore;
using orcamentor.api.Infra.Data;
using orcamentor.api.Model.Repository;
using orcamentor.api.Model.Repository.Interfaces;
using System;

// Comandos
// Gerar migração inicial: dotnet ef migrations add InitialCreate --verbose --context AppTechStudentsDbContext
// Comando para aplicar migration: dotnet ef database update --project orcamentor.api --verbose --context AppTechStudentsDbContext

var builder = WebApplication.CreateBuilder(args);

//Banco 

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var carruxConnectionString = builder.Configuration.GetConnectionString("CarruxConnection");
var techStudentsConnectionString = builder.Configuration.GetConnectionString("TechStudentsConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));

// Postgree
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(connectionString));
//builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddDbContext<AppCarruxDbContext>(options => 
                options.UseMySql(carruxConnectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

// Adicionar centexto de banco de dados para o domínio -> TechStudents
builder.Services.AddDbContext<AppTechStudentsDbContext>(options =>
                options.UseMySql(techStudentsConnectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
// Adicionar injeções do domínio -> TechStudents
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

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
