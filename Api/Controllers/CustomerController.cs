using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IBillService _billService;
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IMapper mapper, ICustomerService customerService,IBillRepository billRepository, IBillService billService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _customerService = customerService;
            _unitOfWork = unitOfWork;
            _billRepository = billRepository;
            _billService = billService;
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

        // GET: api/Bill/5/total
        [HttpGet("{ID}/total")]
        public async Task<IActionResult> GetBillTotal(int ID)
        {
            try
            {
                // Busca a fatura pelo ID do cliente
                var bill = await _billRepository.GetBillByCustomerID(ID);
                
                // Se a fatura não for encontrada, retorna NotFound
                if (bill == null)
                    return NotFound();

                // Calcula o valor total da fatura com base nos serviços associados
                double totalAmount = await _billService.CalculateBill(bill);

                // Atualiza o valor da fatura
                bill.Amount = totalAmount;

                // Constrói um BillDTO com o valor do Amount atualizado
                var billDTO = new BillDTO
                {
                    BillID = bill.BillID,
                    CustomerFK = bill.CustomerFK,
                    ServiceFK = bill.ServiceFK,
                    Amount = bill.Amount
                };

                // Retorna o BillDTO com o valor atualizado
                return Ok(billDTO);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna um StatusCode 500 com a mensagem de erro
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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