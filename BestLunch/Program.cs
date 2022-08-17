using Domain.BAC;
using Domain.Interface;
using Repository.Repository;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Add services to the container.
builder.Services.AddSingleton<IRestauranteBAC, RestauranteBAC>();
builder.Services.AddSingleton<IRestauranteRepo, RestauranteRepo>();
builder.Services.AddSingleton<IUsuarioBAC, UsuarioBAC>();
builder.Services.AddSingleton<IUsuarioRepo, UsuarioRepo>();
builder.Services.AddSingleton<IVotoRepo, VotoRepo>();
builder.Services.AddSingleton<IVotoBAC, VotosBAC>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
