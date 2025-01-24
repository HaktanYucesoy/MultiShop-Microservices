

using MultiShop.Catalog.Constables.Messages.Product;

namespace MultiShop.Catalog.Exceptions.Product
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException():base(ProductMessages.NOT_FOUND)
        {
           
        }       
    }
}
