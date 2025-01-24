using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class FailDeleteProductDetailException:Exception
    {
        public FailDeleteProductDetailException():base(ProductDetailMessages.ERROR_OCCURED_WHILE_DELETING_PRODUCT_DETAIL)
        {
            
        }
    }
}
