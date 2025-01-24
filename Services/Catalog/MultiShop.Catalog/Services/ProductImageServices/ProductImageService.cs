using AutoMapper;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : BaseMongoService<ProductImage, ResultProductImageDto,
        CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto>, IProductImageService
    {
        public ProductImageService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, collectionName:databaseSettings.ProductImageCollectionName, mapper)
        {
        }
    }
}
