
namespace MultiShop.Order.Application.Exceptions.OrderDetail
{
    public class OrderDetailDomainRuleException: Exception
    {
        public OrderDetailDomainRuleException(string orderDetailDomainException):base(orderDetailDomainException)
        {

        }
    }
}
