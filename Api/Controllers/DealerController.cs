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
    public class DealerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDealerService _dealerService;
        private readonly IUnitOfWork _unitOfWork;

        public DealerController(IMapper mapper, IDealerService dealerService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dealerService = dealerService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealerDTO>>> GetAllDealers()
        {
            var dealers = await _dealerService.GetAllEntity();
            var dealerDTOs = _mapper.Map<IEnumerable<DealerDTO>>(dealers);
            _unitOfWork.Commit();
            return Ok(dealerDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealerDTO>> GetDealerById(int id)
        {
            var dealer = await _dealerService.GetOneEntity(id);
            var dealerDTO = _mapper.Map<DealerDTO>(dealer);
            _unitOfWork.Commit();
            return Ok(dealerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<DealerDTO>> AddDealer([FromBody] DealerDTO dealerDTO)
        {
            var addedDealer = await _dealerService.AddEntity(dealerDTO);
            var addedDealerDTO = _mapper.Map<DealerDTO>(addedDealer);
            _unitOfWork.Commit();
            return Ok(addedDealerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DealerDTO>> UpdateDealer(int id, [FromBody] DealerDTO dealerDTO)
        {
            var updatedDealer = await _dealerService.UpdateEntity(id, dealerDTO);
            var updatedDealerDTO = _mapper.Map<DealerDTO>(updatedDealer);
            _unitOfWork.Commit();
            return Ok(updatedDealerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDealer(int id)
        {
            await _dealerService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}