using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;
        public BillController(IBillRepository billRepository, IMapper mapper)
        {
            _mapper = mapper;
            _billRepository = billRepository;
        }


    }
}