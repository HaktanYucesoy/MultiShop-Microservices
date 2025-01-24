

using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductImage
{
    public class FailAddProductImageException:Exception
    {
        public FailAddProductImageException():base(ProductImageMessages.ERROR_OCCURED_WHILE_ADDING_PRODUCT_IMAGE)
        {
            
        }
    }
}
