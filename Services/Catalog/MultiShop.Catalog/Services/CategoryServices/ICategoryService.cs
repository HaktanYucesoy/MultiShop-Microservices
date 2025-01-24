using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.BaseService;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService:IBaseService<ResultCategoryDto,CreateCategoryDto,
        UpdateCategoryDto,GetByIdCategoryDto>
    {
        

    }
}
