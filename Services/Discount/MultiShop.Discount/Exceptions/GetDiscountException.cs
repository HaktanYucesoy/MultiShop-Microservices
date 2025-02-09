using MultiShop.Discount.Constables.Messages;

namespace MultiShop.Discount.Exceptions
{
    public class GetDiscountException:Exception
    {
        public Exception actualException;
        public GetDiscountException(Exception actualException) : base(DiscountExceptionMessages.ErrorOccuredWhileGettingDiscount)
        {
            this.actualException = actualException;
        }
    }
}
