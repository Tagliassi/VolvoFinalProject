using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Model.DTO;

namespace VolvoFinalProject.Api.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bill, BillDTO>().ReverseMap();
            CreateMap<CategoryService, CategoryServiceDTO>().ReverseMap();
            CreateMap<Contacts, ContactsDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Dealer, DealerDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Parts, PartsDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
        }
    }
}