using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models
{
    public class ProjectContext : DbContext
    {
        // Tabelas do banco de dados
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<CategoryService> CategoryServices { get; set; } = null!;
        public virtual DbSet<Contacts> Contact { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Dealer> Dealers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Parts> Part { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        public ProjectContext()
        {
        }
       
        // Configuração do contexto
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
    }
}