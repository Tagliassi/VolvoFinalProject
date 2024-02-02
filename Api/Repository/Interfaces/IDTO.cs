using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    // Exemplo de contrato para um DTO
    public interface IDTO<T>
    {
        // Método para criar uma entidade a partir do DTO
        T CreateEntity();
    }
}