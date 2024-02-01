using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Interfaces;

namespace VolvoFinalProject.Api.Models.DTO
{
    // Classe que representa um DTO (Data Transfer Object) para a entidade Dealer
    // Implementa o contrato
    public class DealerDTO : IDTO<Dealer>
    {
        // Propriedades correspondentes aos campos da entidade Dealer
        public int DealerID { get; set; }
        public int ContactFK { get; set; }
        public int ServiceFK { get; set; }
        public int EmployeeFK { get; set; }
        public int CostumerFK { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }

        // Propriedades DTO para entidades relacionadas
        public ContactsDTO Contact { get; set; }
        public ServiceDTO Service { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CustomerDTO Customer { get; set; }

        // Construtor padrão sem parâmetros para criar instâncias vazias do DTO
        public DealerDTO() { }

        // Construtor que recebe uma entidade Dealer para realizar a conversão para o DTO
        public DealerDTO(Dealer dealer)
        {
            // Mapeamento das propriedades simples
            DealerID = dealer.DealerID;
            ContactFK = dealer.ContactFK;
            ServiceFK = dealer.ServiceFK;
            EmployeeFK = dealer.EmployeeFK;
            CostumerFK = dealer.CostumerFK;
            CNPJ = dealer.CNPJ;
            Name = dealer.Name;

            // Mapeamento de propriedades relacionadas
            if (dealer.ContactFK != null)
            {
                // Se ContactFK não for nulo, criar uma instância de ContactDTO
                Contact = new ContactsDTO(new Contacts { ContactsID = dealer.ContactFK.Value });
            }

            if (dealer.ServiceFK != null)
            {
                Service = new ServiceDTO(dealer.ServiceFK.Value);
            }

            if (dealer.EmployeeFK != null)
            {
                Employee = new EmployeeDTO(dealer.EmployeeFK.Value);
            }

            if (dealer.CostumerFK != null)
            {
                Customer = new CustomerDTO(dealer.CostumerFK.Value);
            }
        }


        // Método para criar uma entidade Dealer a partir do DTO
        public Dealer CreateEntity()
        {
            return new Dealer()
            {
                // Mapeamento inverso das propriedades
                Name = this.Name != null ? this.Name.ToLower() : this.Name,
                CNPJ = this.CNPJ,
                ContactFK = this.Contact == null ? null : Contact.CreateEntity()
            };
        }
    }
}