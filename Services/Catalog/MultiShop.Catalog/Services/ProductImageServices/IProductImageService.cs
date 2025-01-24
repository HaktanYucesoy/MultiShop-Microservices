using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.BaseService;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService:IBaseService<ResultProductImageDto,CreateProductImageDto,
        UpdateProductImageDto,GetByIdProductImageDto>
    {
        
    }
}
