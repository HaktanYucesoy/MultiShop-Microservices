using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class FailDeleteProductImageException:Exception
    {
        public FailDeleteProductImageException():base(ProductDetailMessages.ERROR_OCCURED_WHILE_DELETING_PRODUCT_DETAIL)
        {
            
        }
    }
}
