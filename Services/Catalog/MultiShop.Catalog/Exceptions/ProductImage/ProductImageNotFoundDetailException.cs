using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductImage
{
    public class ProductImageNotFoundException:Exception
    {
        public ProductImageNotFoundException():base(ProductImageMessages.NOT_FOUND)
        {
           
        }       
    }
}
