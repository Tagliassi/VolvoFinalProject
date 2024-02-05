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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CustomerFK);

            modelBuilder.Entity<CategoryService>()
                .HasOne(cs => cs.Service)
                .WithMany(s => s.CategoryServices)
                .HasForeignKey(cs => cs.ServiceFK);
            
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Service)
                .WithMany(s => s.Customers)
                .HasForeignKey(c => c.ServiceFK);
            
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerFK);

            modelBuilder.Entity<Dealer>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Dealer)
                .HasForeignKey(e => e.DealerFK);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Service)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.ServiceFK);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Vehicle)
                .WithMany(v => v.Services)
                .HasForeignKey(s => s.VehicleFK);
        }
    }
}