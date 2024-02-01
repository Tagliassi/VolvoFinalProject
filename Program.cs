using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using VolvoFinalProject.Api.Models;
using VolvoFinalProject.Api.RepositoryInterfaces;
using VolvoFinalProject.Api.Repository;
using VolvoFinalProject.Api.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VolvoFinalProject.Api.AutoMappers;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

// Application Services.



// Add logging service
builder.Services.AddLogging();
builder.Services.AddDbContext<ProjectContext>(opt => opt.UseSqlServer("VolvoFinalProject"));

var app = builder.Build();

// Use Middleware 
app.UseMiddleware(typeof(ErrorMiddleware));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();