
using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class ProductDetailNotFoundDetailException:Exception
    {
        public ProductDetailNotFoundDetailException():base(ProductDetailMessages.NOT_FOUND)
        {
           
        }       
    }
}
