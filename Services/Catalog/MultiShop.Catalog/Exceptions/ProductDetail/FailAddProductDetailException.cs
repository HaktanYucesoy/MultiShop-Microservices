

using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class FailAddProductImageException:Exception
    {
        public FailAddProductImageException():base(ProductDetailMessages.ERROR_OCCURED_WHILE_ADDING_PRODUCT_DETAIL)
        {
            
        }
    }
}
