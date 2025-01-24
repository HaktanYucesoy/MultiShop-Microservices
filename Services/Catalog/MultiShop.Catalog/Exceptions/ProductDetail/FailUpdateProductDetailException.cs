

using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class FailUpdateProductDetailException:Exception
    {
        public FailUpdateProductDetailException():base(ProductDetailMessages.ERROR_OCCURED_WHILE_UPDATING_PRODUCT_DETAIL)
        {
            
        }
    }
}
