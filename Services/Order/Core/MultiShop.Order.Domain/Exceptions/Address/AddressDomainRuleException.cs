namespace MultiShop.Order.Domain.Exceptions.Address
{
    public class AddressDomainRuleException : Exception
    {
        public AddressDomainRuleException(string addressDomainRuleMessage) : base(addressDomainRuleMessage)
        {
        }
    }
}
