

using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class FailAddProductDetailException:Exception
    {
        public FailAddProductDetailException():base(ProductDetailMessages.ERROR_OCCURED_WHILE_ADDING_PRODUCT_DETAIL)
        {
            
        }
    }
}
