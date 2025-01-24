using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class ProductImageNotFoundDetailException:Exception
    {
        public ProductImageNotFoundDetailException():base(ProductImageMessages.NOT_FOUND)
        {
           
        }       
    }
}
