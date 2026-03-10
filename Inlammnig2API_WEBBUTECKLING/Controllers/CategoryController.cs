using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlammnig2API_WEBBUTECKLING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost ("Create")]

        public IActionResult CreateCategory([FromBody] CategoryDTO dto)
        {
            var result = _categoryService.CreateCategory(dto);
            if (result == null)
            {
                return BadRequest("Failed to create category");
            }
            return Created($"api/post/{result.Id}", result);
        }

       [HttpGet("GetAll")]

        public IActionResult GetAllCategories()
        {
          var result = _categoryService.GetAllCategories();
          return Ok(result);

        }
    }
}
