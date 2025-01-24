using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class FailUpdateProductException:Exception
    {
        public FailUpdateProductException():base(CategoryMessages.ERROR_OCCURED_WHILE_UPDATING_CATEGORY)
        {
            
        }
    }
}
