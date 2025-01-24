using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : BaseMongoService<Category, ResultCategoryDto,
        CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto>,
        ICategoryService
    {
        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, collectionName:databaseSettings.CategoryCollectionName, mapper)
        {
        }
    }
}
