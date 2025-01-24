using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.BaseService;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService:IBaseService<ResultProductDto,CreateProductDto,UpdateProductDto,GetByIdProductDto>
    {
        
    }
}
