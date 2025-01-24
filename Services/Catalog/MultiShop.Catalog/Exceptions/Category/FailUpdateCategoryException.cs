using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class FailUpdateCategoryException:Exception
    {
        public FailUpdateCategoryException():base(CategoryMessages.ERROR_OCCURED_WHILE_UPDATING_CATEGORY)
        {
            
        }
    }
}
