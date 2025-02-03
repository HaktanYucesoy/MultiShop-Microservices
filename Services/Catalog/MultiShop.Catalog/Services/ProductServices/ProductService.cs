using AutoMapper;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Aspects.Mappings;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : BaseMongoService<Product, ResultProductDto,
        CreateProductDto, UpdateProductDto, GetByIdProductDto,ProductService>, IProductService
    {
        public ProductService(IDatabaseSettings databaseSettings,IMapper mapper, DomainExceptionRegistery domainExceptionRegistery) : base(databaseSettings, collectionName:databaseSettings.ProductCollectionName, mapper,
            domainExceptionRegistery)
        {
        }
    }
}
