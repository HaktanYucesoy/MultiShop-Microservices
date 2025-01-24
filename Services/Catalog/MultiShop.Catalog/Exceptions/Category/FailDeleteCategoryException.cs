using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class FailDeleteCategoryException:Exception
    {
        public FailDeleteCategoryException():base(CategoryMessages.ERROR_OCCURED_WHILE_DELETING_CATEGORY)
        {
            
        }
    }
}
