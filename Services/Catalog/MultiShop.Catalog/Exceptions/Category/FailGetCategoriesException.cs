using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class FailGetCategoriesException : Exception
    {
        public FailGetCategoriesException() : base(CategoryMessages.ERROR_OCCURED_WHILE_GET_CATEGORİES)
        {
        }
    }
}
