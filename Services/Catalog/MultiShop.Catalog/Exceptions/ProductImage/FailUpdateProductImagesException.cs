
using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductImage
{
    public class FailUpdateProductImageException:Exception
    {
        public FailUpdateProductImageException():base(ProductImageMessages.ERROR_OCCURED_WHILE_UPDATING_PRODUCT_IMAGE)
        {
            
        }
    }
}
