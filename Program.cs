using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.DTOService.Services;
using VolvoFinalProject.Api.Middlewares;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuration of Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Log to the console
    .WriteTo.File("C:\\VolvoFinalProject\\Api\\log.txt", rollingInterval: RollingInterval.Day) // Log to a file with daily rotation
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .ReadFrom.Configuration(builder.Configuration) // Configuration from appsettings.json
    .MinimumLevel.ControlledBy(new Serilog.Core.LoggingLevelSwitch
    {
        MinimumLevel = GetLogLevel() // Get the configured detail level
    })
    .CreateLogger();

builder.Logging.ClearProviders(); // Remove default providers
builder.Logging.AddSerilog(); // Add the Serilog provider

LogEventLevel GetLogLevel()
{
    var defaultLogLevel = LogEventLevel.Information;

    // Get the detail level configured in appsettings.json
    var logLevel = builder.Configuration.GetValue<string>("Logging:LogLevel:Default");

    return Enum.TryParse<LogEventLevel>(logLevel, out var result) ? result : defaultLogLevel;
}

// Configure services and application
builder.Services.AddLogging();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICategoryServiceRepository, CategoryServiceRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBillRepository, BillRepository>();
builder.Services.AddTransient<IContactsRepository, ContactsRepository>();
builder.Services.AddTransient<IPartsRepository, PartsRepository>();
builder.Services.AddTransient<IDealerRepository, DealerRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();

builder.Services.AddTransient<ICategoryServiceService, CategoryServiceService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddTransient<IContactsService, ContactsService>();
builder.Services.AddTransient<IPartsService, PartsService>();
builder.Services.AddTransient<IDealerService, DealerService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the application using Startup class
var app = builder.Build();
var env = app.Environment;

app.UseMiddleware<ErrorMiddleware>();

if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();