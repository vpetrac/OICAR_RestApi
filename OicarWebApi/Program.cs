using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OicarWebApi.Controllers;
using OicarWebApi.Models;
using System.Configuration;



var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("cs");

//builder.Services.AddScoped<UserController>();

builder.Services.AddDbContext<OicarAppDatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
