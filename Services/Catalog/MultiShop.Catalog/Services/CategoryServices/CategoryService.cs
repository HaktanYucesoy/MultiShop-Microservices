using AutoMapper;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Aspects.Mappings;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : BaseMongoService<Category, ResultCategoryDto,
        CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto,CategoryDomain>,
        ICategoryService
    {
        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper,
            DomainExceptionRegistery domainExceptionRegistery) : base(databaseSettings, collectionName:databaseSettings.CategoryCollectionName, mapper,domainExceptionRegistery,typeof(CategoryDomain))
        {
        }
    }
}
