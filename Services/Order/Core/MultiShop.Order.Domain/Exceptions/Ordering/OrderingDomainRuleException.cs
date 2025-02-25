namespace MultiShop.Order.Domain.Exceptions.Ordering
{
    public class OrderingDomainRuleException:Exception
    {
        public OrderingDomainRuleException(string orderingMessage) : base(orderingMessage)
        {
            
        }
    }
}
