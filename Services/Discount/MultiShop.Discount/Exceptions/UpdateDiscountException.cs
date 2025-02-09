using MultiShop.Discount.Constables.Messages;

namespace MultiShop.Discount.Exceptions
{
    public class UpdateDiscountException:Exception
    {
        public Exception actualException;
        public UpdateDiscountException(Exception actualException) : base(DiscountExceptionMessages.ErrorOccuredWhileUpdatingDiscount)
        {
            this.actualException = actualException;
        }
    }
}
