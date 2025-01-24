

using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductImage
{
    public class FailDeleteProductImageException:Exception
    {
        public FailDeleteProductImageException():base(ProductImageMessages.ERROR_OCCURED_WHILE_DELETING_PRODUCT_IMAGE)
        {
            
        }
    }
}
