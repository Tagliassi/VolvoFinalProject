using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBillService _billService;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor to initialize dependencies
        public BillController(IMapper mapper, IBillService billService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _billService = billService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bill
        // Get all bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDTO>>> GetAllBills()
        {
            var bills = await _billService.GetAllEntity();
            var billDTOs = _mapper.Map<IEnumerable<BillDTO>>(bills);
            _unitOfWork.Commit();
            return Ok(billDTOs);
        }

        // GET: api/Bill/5
        // Get a specific bill by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDTO>> GetBillById(int id)
        {
            var bill = await _billService.GetOneEntity(id);
            var billDTO = _mapper.Map<BillDTO>(bill);
            _unitOfWork.Commit();
            return Ok(billDTO);
        }

        // POST: api/Bill
        // Add a new bill
        [HttpPost]
        public async Task<ActionResult<BillDTO>> AddBill([FromBody] BillDTO billDTO)
        {
            var addedBill = await _billService.AddEntity(billDTO);
            var addedBillDTO = _mapper.Map<BillDTO>(addedBill);
            //return CreatedAtAction(nameof(GetBillById), new { id = addedBillDTO.BillID }, addedBillDTO);
            _unitOfWork.Commit();
            return Ok(addedBillDTO);
        }

        // PUT: api/Bill/5
        // Update an existing bill by ID
        [HttpPut("{id}")]
        public async Task<ActionResult<BillDTO>> UpdateBill(int id, [FromBody] BillDTO billDTO)
        {
            var updatedBill = await _billService.UpdateEntity(id, billDTO);
            var updatedBillDTO = _mapper.Map<BillDTO>(updatedBill);
            _unitOfWork.Commit();
            return Ok(updatedBillDTO);
        }

        // DELETE: api/Bill/5
        // Delete a bill by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBill(int id)
        {
            await _billService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}