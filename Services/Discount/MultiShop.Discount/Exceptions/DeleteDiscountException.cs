using MultiShop.Discount.Constables.Messages;

namespace MultiShop.Discount.Exceptions
{
    public class DeleteDiscountException: Exception
    {
        public Exception actualException;
        public DeleteDiscountException(Exception actualException) : base(DiscountExceptionMessages.ErrorOccuredWhileDeletingDiscount)
        {
            this.actualException = actualException;
        }
    }
}
