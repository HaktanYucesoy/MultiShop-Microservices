using MultiShop.Catalog.Aspects.Domains;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Exceptions.Category;

namespace MultiShop.Catalog.Aspects.Mappings
{
    public class CategoryExceptionMapping
    {

        private static readonly Lazy<DomainExceptionMap<CategoryDomain>> _mapping =
           new(() => new DomainExceptionMap<CategoryDomain>
           {
               NotFoundException = typeof(CategoryNotFoundException),
               CreateFailedException = typeof(FailAddCategoryException),
               DeleteFailedException = typeof(FailDeleteCategoryException),
               UpdateFailedException = typeof(FailUpdateCategoryException),
               GetFailedException = typeof(FailGetCategoriesException)
           });

        public static DomainExceptionMap<CategoryDomain> GetExceptionMap() => _mapping.Value;
    }

   
}
