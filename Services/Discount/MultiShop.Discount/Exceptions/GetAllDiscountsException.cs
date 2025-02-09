using MultiShop.Discount.Constables.Messages;

namespace MultiShop.Discount.Exceptions
{
    public class GetAllDiscountsException : Exception
    {
        public Exception actualException;
        public GetAllDiscountsException(Exception actualException) : base(DiscountExceptionMessages.ErrorOccuredWhileGettingDiscounts)
        {
            this.actualException = actualException;
        }
    }
}
