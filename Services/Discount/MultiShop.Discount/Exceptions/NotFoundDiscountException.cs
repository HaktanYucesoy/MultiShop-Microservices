using MultiShop.Discount.Constables.Messages;

namespace MultiShop.Discount.Exceptions
{
    public class NotFoundDiscountException:Exception
    {
       
        public NotFoundDiscountException() : base(DiscountExceptionMessages.NotDiscountFound)
        {
           
        }
    }
}
