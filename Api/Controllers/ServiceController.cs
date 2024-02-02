using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Model.Models.Enum;
using VolvoFinalProject.Api.DTOService.Services;
using VolvoFinalProject.Api.DTOService.Interfaces;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ServiceService _service;

        public ServiceController(IMapper mapper, ServiceService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPatch("{id}/update-status")]
        public async Task<IActionResult> UpdateServiceStatus(int id, [FromBody] EnumSituation newStatus)
        {
            try
            {
                var updatedService = await _service.UpdateServiceStatus(id, newStatus);
                return Ok(updatedService);
            }
            catch (ErrorViewModel error)
            {
                return BadRequest(error);
            }
        }
    }
}