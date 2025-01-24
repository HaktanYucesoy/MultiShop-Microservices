using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class CategoryNotFoundException:Exception
    {
        public CategoryNotFoundException():base(CategoryMessages.NOT_FOUND)
        {
           
        }

        
    }
}
