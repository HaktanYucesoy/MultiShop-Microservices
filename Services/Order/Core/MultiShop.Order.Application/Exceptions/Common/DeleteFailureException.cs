
namespace MultiShop.Order.Application.Exceptions.Common
{
    public class DeleteFailureException:Exception
    {
        public string DomainName { get; set; }
        public int Id { get; set; }
        public string ExtendedMessage { get; set; }
        public DeleteFailureException(string domainName, int id, string extendedMessage)
            : base($"Failed to delete {domainName} with id {id}. {extendedMessage}")
        {
            domainName = DomainName;
            Id = id;
            ExtendedMessage = extendedMessage;
        }
    }
}
