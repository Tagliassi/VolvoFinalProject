using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Interfaces;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class CustomerDTO : IDTO<Customer>
    {
        public Customer CreateEntity()
        {
            throw new NotImplementedException();
        }
    }
}