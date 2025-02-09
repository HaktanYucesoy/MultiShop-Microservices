using MultiShop.Discount.Constables.Messages;

namespace MultiShop.Discount.Exceptions
{
    public class CreateDiscountException: Exception
    {
        public Exception actualException;
        public CreateDiscountException(Exception actualException) : base(DiscountExceptionMessages.ErrorOccuredWhileAddingDiscount)
        {
            this.actualException = actualException;
        }
    }
}
