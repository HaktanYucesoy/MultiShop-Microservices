
using MultiShop.Catalog.Constables.Messages.ProductImage;

namespace MultiShop.Catalog.Exceptions.ProductImage
{
    public class FailGetProductImagesException : Exception
    {
        public FailGetProductImagesException() : base(ProductImageMessages.ERROR_OCCURED_WHILE_GET_PRODUCT_IMAGES)
        {
        }
    }
}
