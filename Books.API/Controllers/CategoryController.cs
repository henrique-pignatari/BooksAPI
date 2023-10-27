using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorySendDTO>>> Get()
        {
            var categories = await _categoryService.GetAllAsync();

            if (categories == null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategorySendDTO>> Get(string id)
        {
            var categorySendDTO = await _categoryService.GetByIdAsync(id);

            if (categorySendDTO == null)
            {
                return NotFound("Category not found");
            }

            return Ok(categorySendDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryReceiveDTO categoryReceiveDTO)
        {
            if (categoryReceiveDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            var categorySendDTO = await _categoryService.CreateAsync(categoryReceiveDTO);

            return CreatedAtRoute("GetCategory", new { id = categorySendDTO.Id }, categorySendDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategorySendDTO categoryReceiveDTO)
        {
            if (categoryReceiveDTO == null) return BadRequest();

            var categorySendDTO = await _categoryService.UpdateAsync(categoryReceiveDTO);

            if (categorySendDTO == null) return BadRequest();

            return Ok(categorySendDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var categorySendDTO = await _categoryService.RemoveAsync(id);

            if (categorySendDTO == null) return BadRequest();

            return Ok();
        }
    }
}
