using Asp.Versioning;
using Microsoft.AspNetCore.Http;
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
    }
}
