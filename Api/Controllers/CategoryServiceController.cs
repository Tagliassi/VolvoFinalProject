using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        public CategoryServiceController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}