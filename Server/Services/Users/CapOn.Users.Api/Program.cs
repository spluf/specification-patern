using Capon.Users.Persistance;
using Capon.Users.Persistance.Sql;
using Capon.Users.ServiceBuilder;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add the whole configuration object here.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Register services
UserServiceBuilder.Register(builder.Services, builder.Configuration);

// Add services to the container.
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
