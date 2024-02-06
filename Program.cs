using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using VolvoFinalProject.Api.AutoMappers;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.DTOService.Services;
using VolvoFinalProject.Api.Middlewares;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder);

// Configure application
var app = builder.Build();
var env = app.Environment;

// Additional configuration based on environment
ConfigureEnvironment(app, env);

// Use middleware
app.UseMiddleware<ErrorMiddleware>();

// Run the application
app.Run();

LogEventLevel GetLogLevel()
{
    var defaultLogLevel = LogEventLevel.Information;

    // Get the detail level configured in appsettings.json
    var logLevel = builder.Configuration.GetValue<string>("Logging:LogLevel:Default");

    return Enum.TryParse<LogEventLevel>(logLevel, out var result) ? result : defaultLogLevel;
}

void ConfigureServices(WebApplicationBuilder builder)
{
    // Add controllers and endpoints
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Application Automapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

    // Register DbContext
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connection));

    // Configuration of Serilog
    ConfigureSerilog(builder);

    // Configure services
    RegisterRepositories(builder);
    RegisterServices(builder);
}

void ConfigureSerilog(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("C:\\VolvoFinalProject\\Api\\log.txt", rollingInterval: RollingInterval.Day)
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .ReadFrom.Configuration(builder.Configuration)
        .MinimumLevel.ControlledBy(new Serilog.Core.LoggingLevelSwitch
        {
            MinimumLevel = GetLogLevel()
        })
        .CreateLogger();

    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog();
}

void RegisterRepositories(WebApplicationBuilder builder)
{
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
}

void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ICategoryServiceService, CategoryServiceService>();
    builder.Services.AddTransient<IServiceService, ServiceService>();
    builder.Services.AddTransient<IBillService, BillService>();
    builder.Services.AddTransient<IContactsService, ContactsService>();
    builder.Services.AddTransient<IPartsService, PartsService>();
    builder.Services.AddTransient<IDealerService, DealerService>();
    builder.Services.AddTransient<IEmployeeService, EmployeeService>();
    builder.Services.AddTransient<ICustomerService, CustomerService>();
    builder.Services.AddTransient<IVehicleService, VehicleService>();
}

void ConfigureEnvironment(WebApplication app, IHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI v1"));
    }

    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseAuthorization();

    app.MapControllers();
}