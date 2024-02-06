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
       
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer>()
                .HasOne(d => d.Contacts)
                .WithMany()
                .HasForeignKey(d => d.ContactFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Dealer)
                .WithMany()
                .HasForeignKey(e => e.DealerFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Contacts)
                .WithMany()
                .HasForeignKey(e => e.ContactFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Contacts)
                .WithMany()
                .HasForeignKey(c => c.ContactFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany()
                .HasForeignKey(v => v.CustomerFK)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Dealer)
                .WithMany()
                .HasForeignKey(s => s.DealerFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CategoryService>()
                .HasOne(cs => cs.Service)
                .WithMany()
                .HasForeignKey(cs => cs.ServiceFK)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Parts>()
                .HasOne(p => p.CategoryService)
                .WithMany()
                .HasForeignKey(p => p.CategoryServiceFK)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Service)
                .WithMany()
                .HasForeignKey(b => b.ServiceFK)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}