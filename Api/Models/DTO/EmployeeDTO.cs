using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Interfaces;
using VolvoFinalProject.Api.Models.Enum;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class EmployeeDTO : IDTO<Employee>
    {
        public int EmployeeID { get; set; }
        public int DealerFK { get; set; }
        public int ServiceFK { get; set; }
        public int ContactFK { get; set; }
        public float Salary { get; set; }
        public float BaseSalary { get; set; }
        public float Commission { get; set; }
        public string? CPF { get; set; }
        public string? Name { get; set; }
        public EnumEmployees Employees { get; set; }

        public EmployeeDTO() { }

        public EmployeeDTO(Employee employee)
        {
            EmployeeID = employee.EmployeeID;
            DealerFK = employee.DealerFK;
            ServiceFK = employee.ServiceFK;
            ContactFK = employee.ContactFK;
            Salary = employee.Salary;
            BaseSalary = employee.BaseSalary;
            Commission = employee.Commission;
            CPF = employee.CPF;
            Name = employee.Name;
            Employees = employee.Employees;
        }

        public Employee CreateEntity()
        {
            return new Employee
            {
                // Mapeamento inverso das propriedades
                DealerFK = this.DealerFK,
                ServiceFK = this.ServiceFK,
                ContactFK = this.ContactFK,
                Salary = this.Salary,
                BaseSalary = this.BaseSalary,
                Commission = this.Commission,
                CPF = this.CPF,
                Name = this.Name,
                Employees = this.Employees
            };
        }
    }
}