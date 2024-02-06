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
using VolvoFinalProject.Api.DTOService.Services;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartsService _partsService;
        private readonly ICategoryServiceRepository _categoryServiceRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PartsController(IMapper mapper, IPartsService partsService,ICategoryServiceRepository categoryServiceRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _partsService = partsService;
            _unitOfWork = unitOfWork;
            _categoryServiceRepository = categoryServiceRepository;
        }
        
        // GET: api/Parts
        // Get all parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartsDTO>>> GetAllParts()
        {
            var part = await _partsService.GetAllEntity();
            var partsDTOs = _mapper.Map<IEnumerable<PartsDTO>>(part);
            _unitOfWork.Commit();
            return Ok(partsDTOs);
        }

        // GET: api/Parts/5
        // Get a specific parts by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PartsDTO>> GetPartsById(int id)
        {
            var parts = await _partsService.GetOneEntity(id);
            var partsDTO = _mapper.Map<PartsDTO>(parts);
            _unitOfWork.Commit();
            return Ok(partsDTO);
        }

        // GET: api/Parts/5/service
        [HttpGet("{id}/CategoryService")]
        public async Task<ActionResult> GetPartsByCategoryService(int id)
        {
            var parts = await _categoryServiceRepository.GetPartsByCategoryService(id);
            return Ok(parts);
        }

        // POST: api/Parts
        // Add a new parts
        [HttpPost]
        public async Task<ActionResult<PartsDTO>> AddParts([FromBody] PartsDTO partsDTO)
        {
            var addedParts = await _partsService.AddEntity(partsDTO);
            var addedPartsDTO = _mapper.Map<PartsDTO>(addedParts);
            //return CreatedAtAction(nameof(GetPartsById), new { id = addedPartsDTO.PartsID }, addedPartsDTO);
            _unitOfWork.Commit();
            return Ok(addedPartsDTO);
        }

        // PUT: api/Parts/5
        // Update an existing parts by ID
        [HttpPut("{id}")]
        public async Task<ActionResult<PartsDTO>> UpdateParts(int id, [FromBody] PartsDTO partsDTO)
        {
            var updatedParts = await _partsService.UpdateEntity(id, partsDTO);
            var updatedPartsDTO = _mapper.Map<PartsDTO>(updatedParts);
            _unitOfWork.Commit();
            return Ok(updatedPartsDTO);
        }

        // DELETE: api/Parts/5
        // Delete a parts by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParts(int id)
        {
            await _partsService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}