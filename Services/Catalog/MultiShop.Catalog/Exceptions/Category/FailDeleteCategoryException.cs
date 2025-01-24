using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class FailDeleteProductException:Exception
    {
        public FailDeleteProductException():base(CategoryMessages.ERROR_OCCURED_WHILE_DELETING_CATEGORY)
        {
            
        }
    }
}
