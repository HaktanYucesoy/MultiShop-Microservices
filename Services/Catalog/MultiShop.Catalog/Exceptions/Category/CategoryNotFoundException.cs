using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException():base(CategoryMessages.NOT_FOUND)
        {
           
        }

        
    }
}
