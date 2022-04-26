
using CabinetDentaire.Services;
using FluentMigrator.Runner;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Postgresql;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.UsePostgreSql(builder.Configuration.GetSection("postgresql"));

builder.Services.UseServices();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
        c.MapType<TimeSpan>(() => new OpenApiSchema
        {
         Type = "string",
            Example = new OpenApiString("00:00:00")
        })
);

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
