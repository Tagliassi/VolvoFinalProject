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


        // Configuração do contexto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=FinalProject;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }

    }
}