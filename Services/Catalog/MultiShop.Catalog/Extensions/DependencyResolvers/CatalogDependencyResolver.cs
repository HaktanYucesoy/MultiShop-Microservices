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

            services.AddDomainService<CategoryDomain, ICategoryService, CategoryService>(
                CategoryExceptionMapping.GetExceptionMap());

            services.AddDomainService<ProductDomain, IProductService, ProductService>(
                ProductExceptionMapping.GetExceptionMap());

            services.AddDomainService<ProductDetailDomain, IProductDetailService, ProductDetailService>(
                ProductDetailExceptionMapping.GetExceptionMap());

            services.AddDomainService<ProductImageDomain, IProductImageService, ProductImageService>(ProductImageExceptionMapping.GetExceptionMap());

            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IProductImageService, ProductImageService>();
            //services.AddScoped<IProductDetailService, ProductDetailService>();
            //services.AddScoped<DomainExceptionRegistery>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           

            return services;
        }
    }
}
