using estudo.infra.Context;
using estudo.infraCrossCuting;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(
    c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite("Data source=local.db"));
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().WriteTo.File("Logs/arquivo.txt", rollingInterval : RollingInterval.Day).CreateLogger());
builder.Logging.ClearProviders();

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services
    .SetupDepencencyInjection(configuration);


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
