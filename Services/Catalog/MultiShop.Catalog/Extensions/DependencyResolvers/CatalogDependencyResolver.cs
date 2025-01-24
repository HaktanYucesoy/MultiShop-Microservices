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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService,ProductImageService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           

            return services;
        }
    }
}
