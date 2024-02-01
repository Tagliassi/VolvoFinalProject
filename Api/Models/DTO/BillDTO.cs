using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Interfaces;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class BillDTO : IDTO<Bill>
    {
        public int BillID { get; set; }
        public int CustomerFK { get; set; }
        public int ServiceFK { get; set; }
        public double Amount { get; set; }

        public Bill CreateEntity(Customer Customer, Service Service) 
        {
            return new Bill()
            {
                BillID = this.BillID,
                CustomerFK = Customer,
                ServiceFK = Service,
                Amount = this.Amount
            };
        }

        public Bill CreateEntity()
        {
            throw new NotImplementedException();
        }
    }
}