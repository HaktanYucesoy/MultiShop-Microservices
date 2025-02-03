using AutoMapper;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Aspects.Mappings;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : BaseMongoService<ProductImage, ResultProductImageDto,
        CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto,ProductImageDomain>, IProductImageService
    {
        public ProductImageService(IDatabaseSettings databaseSettings, IMapper mapper,
            DomainExceptionRegistery domainExceptionRegistery) : base(databaseSettings, collectionName:databaseSettings.ProductImageCollectionName, mapper,domainExceptionRegistery)
        {
        }
    }
}
