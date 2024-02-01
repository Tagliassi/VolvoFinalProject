using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Models
{
    public class ProjectContext : DbContext
    {
        // Tabelas do banco de dados
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<CategoryService> CategoryServices { get; set; } = null!;
        public virtual DbSet<Contacts> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Dealer> Dealers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Parts> Parts { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
       
        // Configuração do contexto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=FinalProject;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}