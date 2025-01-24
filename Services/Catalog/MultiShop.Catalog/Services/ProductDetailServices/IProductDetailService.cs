using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.BaseService;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService:IBaseService<ResultProductDetailDto,CreateProductDetailDto,
        UpdateProductDetailDto,GetByIdProductDetailDto>
    {
    }
}
