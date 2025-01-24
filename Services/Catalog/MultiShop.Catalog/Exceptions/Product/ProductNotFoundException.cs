

using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class ProductNotFoundDetailException:Exception
    {
        public ProductNotFoundDetailException():base(ProductMessages.NOT_FOUND)
        {
           
        }       
    }
}
