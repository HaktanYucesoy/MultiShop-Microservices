using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ResponseDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers.v1
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:ApiVersion}")]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet("list")]
        public async Task<ActionResult<ResponseDto<List<ResultCategoryDto>>>> GetCategories()
        {
            var list = await _categoryService.GetAllAsync();
            var response=new ResponseDto<List<ResultCategoryDto>>(list, "Categories listed successfully", 200);
            return StatusCode(response.Status, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<GetByIdCategoryDto>>> GetCategory(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var response = new ResponseDto<GetByIdCategoryDto>(category, "Category got successfully", 200);
            return StatusCode(response.Status, response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto>> AddCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateAsync(createCategoryDto);
            var response = new ResponseDto("Category added successfully", 200);
            return StatusCode(response.Status, response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ResponseDto>> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateAsync(updateCategoryDto);
            var response = new ResponseDto("Category updated successfully", 200);
            return StatusCode(response.Status, response);
        }

        [HttpDelete("delete/{id}")]
        public  async Task<ActionResult<ResponseDto>> DeleteCategory(string id)
        {
            await _categoryService.DeleteAsync(id);
            var response = new ResponseDto("Category deleted successfully", 200);
            return StatusCode(response.Status, response);
        }
    }
}
