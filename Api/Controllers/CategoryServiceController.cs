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
    public class CategoryServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryServiceService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServiceController(IMapper mapper, ICategoryServiceService categoryService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryServiceDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllEntity();
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryServiceDTO>>(categories);
            _unitOfWork.Commit();
            return Ok(categoryDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryServiceDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetOneEntity(id);
            var categoryDTO = _mapper.Map<CategoryServiceDTO>(category);
            _unitOfWork.Commit();
            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryServiceDTO>> AddCategory([FromBody] CategoryServiceDTO categoryDTO)
        {
            var addedCategory = await _categoryService.AddEntity(categoryDTO);
            var addedCategoryDTO = _mapper.Map<CategoryServiceDTO>(addedCategory);
            _unitOfWork.Commit();
            return Ok(addedCategoryDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryServiceDTO>> UpdateCategory(int id, [FromBody] CategoryServiceDTO categoryDTO)
        {
            var updatedCategory = await _categoryService.UpdateEntity(id, categoryDTO);
            var updatedCategoryDTO = _mapper.Map<CategoryServiceDTO>(updatedCategory);
            _unitOfWork.Commit();
            return Ok(updatedCategoryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}