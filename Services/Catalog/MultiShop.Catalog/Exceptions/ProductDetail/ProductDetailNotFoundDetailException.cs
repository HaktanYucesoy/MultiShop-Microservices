
using MultiShop.Catalog.Constables.Messages.ProductDetail;

namespace MultiShop.Catalog.Exceptions.ProductDetail
{
    public class ProductDetailNotFoundException:Exception
    {
        public ProductDetailNotFoundException():base(ProductDetailMessages.NOT_FOUND)
        {
           
        }       
    }
}
