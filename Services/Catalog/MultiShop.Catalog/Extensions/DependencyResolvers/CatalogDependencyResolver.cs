using MultiShop.Catalog.Aspects.Domains;
using MultiShop.Catalog.Aspects.ExceptionHandling;
using MultiShop.Catalog.Aspects.Extensions;
using MultiShop.Catalog.Aspects.Mappings;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using System.Reflection;

namespace MultiShop.Catalog.Extensions.DependencyResolvers
{
    public static class CatalogDependencyResolver
    {
        public static IServiceCollection AddCatalogDependencies(this IServiceCollection services)
        {

            var registry = new DomainExceptionRegistery();

            // Domain exception mapping'leri kaydet
            registry.RegisterExceptions(CategoryExceptionMapping.GetExceptionMap());
            registry.RegisterExceptions(ProductExceptionMapping.GetExceptionMap());
            registry.RegisterExceptions(ProductDetailExceptionMapping.GetExceptionMap());
            registry.RegisterExceptions(ProductImageExceptionMapping.GetExceptionMap());

            // Registry'i singleton olarak ekle
            services.AddSingleton(registry);

            // Servisleri ekle
            services.AddDomainService<CategoryDomain, ICategoryService, CategoryService>(
                registry.GetExceptionMap<CategoryDomain>());
            services.AddDomainService<ProductDomain, IProductService, ProductService>(
                registry.GetExceptionMap<ProductDomain>());
            services.AddDomainService<ProductDetailDomain, IProductDetailService, ProductDetailService>(
                registry.GetExceptionMap<ProductDetailDomain>());
            services.AddDomainService<ProductImageDomain, IProductImageService, ProductImageService>(
                registry.GetExceptionMap<ProductImageDomain>());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
