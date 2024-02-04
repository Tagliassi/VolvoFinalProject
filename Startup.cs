using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using VolvoFinalProject.Api.AutoMappers;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.DTOService.Services;
using VolvoFinalProject.Api.Middlewares;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Repository.Repositories;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Application Automapper
        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.AddControllers();

        // Register DbContext
        services.AddDbContext<ProjectContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Add IConfiguration
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddConfiguration(Configuration); // Preserve existing configuration

        var newConfiguration = configurationBuilder.Build();

        // Configurar o logging
        services.AddLogging(logging =>
        {
            logging.AddConfiguration(Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddSerilog();
        });

        // Application Repositories.
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ICategoryServiceRepository, CategoryServiceRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<IBillRepository, BillRepository>();
        services.AddTransient<IContactsRepository, ContactsRepository>();
        services.AddTransient<IPartsRepository, PartsRepository>();
        services.AddTransient<IDealerRepository, DealerRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IVehicleRepository, VehicleRepository>();

        // Application Service.
        services.AddTransient<ICategoryServiceService, CategoryServiceService>();
        services.AddTransient<IServiceService, ServiceService>();
        services.AddTransient<IBillService, BillService>();
        services.AddTransient<IContactsService, ContactsService>();
        services.AddTransient<IPartsService, PartsService>();
        services.AddTransient<IDealerService, DealerService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IVehicleService, VehicleService>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ErrorMiddleware>();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}