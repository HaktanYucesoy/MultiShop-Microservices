using AutoMapper;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : BaseMongoService<Product, ResultProductDto,
        CreateProductDto, UpdateProductDto, GetByIdProductDto>, IProductService
    {
        public ProductService(IDatabaseSettings databaseSettings,IMapper mapper) : base(databaseSettings, collectionName:databaseSettings.ProductCollectionName, mapper)
        {
        }
    }
}
