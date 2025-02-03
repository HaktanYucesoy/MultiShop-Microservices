using AutoMapper;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Aspects.Mappings;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : BaseMongoService<ProductDetail, ResultProductDetailDto,
        CreateProductDetailDto, UpdateProductDetailDto, GetByIdProductDetailDto,ProductDetailDomain>, IProductDetailService
    {
        public ProductDetailService(IDatabaseSettings databaseSettings, IMapper mapper,
            DomainExceptionRegistery domainExceptionRegistery) : base(databaseSettings, collectionName:databaseSettings.ProductDetailsCollectionName, mapper,domainExceptionRegistery)
        {
        }
    }
}
