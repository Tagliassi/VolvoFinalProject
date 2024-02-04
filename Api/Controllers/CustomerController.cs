using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IMapper mapper, ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllEntity();
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            _unitOfWork.Commit();
            return Ok(customerDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetOneEntity(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            _unitOfWork.Commit();
            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            var addedCustomer = await _customerService.AddEntity(customerDTO);
            var addedCustomerDTO = _mapper.Map<CustomerDTO>(addedCustomer);
            _unitOfWork.Commit();
            return Ok(addedCustomerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int id, [FromBody] CustomerDTO customerDTO)
        {
            var updatedCustomer = await _customerService.UpdateEntity(id, customerDTO);
            var updatedCustomerDTO = _mapper.Map<CustomerDTO>(updatedCustomer);
            _unitOfWork.Commit();
            return Ok(updatedCustomerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}