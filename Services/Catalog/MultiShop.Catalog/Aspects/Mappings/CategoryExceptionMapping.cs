using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Exceptions.Category;

namespace MultiShop.Catalog.Aspects.Mappings
{
    public class CategoryExceptionMapping
    {
        public static DomainExceptionMap<CategoryDomain> GetExceptionMap() =>
        new()
        {
            NotFoundException = typeof(CategoryNotFoundException),
            CreateFailedException = typeof(FailAddCategoryException),
            DeleteFailedException=typeof(FailDeleteCategoryException),
            UpdateFailedException=typeof(FailUpdateCategoryException),
            GetFailedException=typeof(FailGetCategoriesException)
        };
    }

    public class CategoryDomain
    {
    }
}
