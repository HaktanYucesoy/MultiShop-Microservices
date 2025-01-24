using MultiShop.Catalog.Constables.Messages.Category;

namespace MultiShop.Catalog.Exceptions.Category
{
    public class FailGetProductsException : Exception
    {
        public FailGetProductsException() : base(CategoryMessages.ERROR_OCCURED_WHILE_GET_CATEGORİES)
        {
        }
    }
}
