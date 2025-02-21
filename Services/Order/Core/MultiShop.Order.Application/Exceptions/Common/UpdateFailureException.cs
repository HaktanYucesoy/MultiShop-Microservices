
namespace MultiShop.Order.Application.Exceptions.Common
{
    public class UpdateFailureException:Exception
    {
        public string DomainName { get; set; }
        public int Id { get; set; }
        public string ExtendedMessage { get; set; }
        public UpdateFailureException(string domainName, int id, string extendedMessage)
            :base($"Failed to update {domainName} with id {id}. {extendedMessage}")
        {
            domainName = DomainName;
            Id = id;
            ExtendedMessage = extendedMessage;
        }

       
    }
}
