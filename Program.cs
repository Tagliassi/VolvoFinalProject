using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using VolvoFinalProject.Api.Repository;
using VolvoFinalProject.Api.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VolvoFinalProject.Api.AutoMappers;
using AutoMapper;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Repository.Repositories;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.DTOService.Services;
using VolvoFinalProject.Api;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Log para o console
    .WriteTo.File("C:\\VolvoFinalProject\\Api\\log.txt", rollingInterval: RollingInterval.Day) // Log para um arquivo com rotação diária
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .ReadFrom.Configuration(builder.Configuration) // Configurações do appsettings.json
    .MinimumLevel.ControlledBy(new Serilog.Core.LoggingLevelSwitch
    {
        MinimumLevel = GetLogLevel() // Obtém o nível de detalhamento configurado
    })
    .CreateLogger();

builder.Logging.ClearProviders(); // Remover os provedores padrão
builder.Logging.AddSerilog(); // Adicionar o provedor Serilog

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Adicionar IConfiguration
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Configurar o logging
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddSerilog();

LogEventLevel GetLogLevel()
{
    var defaultLogLevel = LogEventLevel.Information;

    // Obter o nível de detalhamento configurado no appsettings.json
    var logLevel = builder.Configuration.GetValue<string>("Logging:LogLevel:Default");

    return Enum.TryParse<LogEventLevel>(logLevel, out var result) ? result : defaultLogLevel;
}

// Application Repositories.
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<ICategoryServiceRepository, CategoryServiceRepository>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDealerRepository, DealerRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPartsRepository, PartsRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Application Service.
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<ICategoryServiceService, CategoryServiceService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPartsService, PartsService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

// Add logging service
builder.Services.AddLogging();
builder.Services.AddDbContext<ProjectContext>(opt => opt.UseSqlServer("VolvoFinalProject"));

var app = builder.Build();

// Use Middleware 
app.UseMiddleware<ErrorMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();