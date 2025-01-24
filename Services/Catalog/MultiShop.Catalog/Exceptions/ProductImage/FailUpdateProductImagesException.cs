
using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductImages
{
    public class FailUpdateProductImagesException:Exception
    {
        public FailUpdateProductImagesException():base(ProductImageMessages.ERROR_OCCURED_WHILE_UPDATING_PRODUCT_IMAGE)
        {
            
        }
    }
}
