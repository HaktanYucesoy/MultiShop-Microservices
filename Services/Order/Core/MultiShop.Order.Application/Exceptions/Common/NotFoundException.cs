
namespace MultiShop.Order.Application.Exceptions.Common
{
    public class NotFoundException:Exception
    {

        public NotFoundException(string name, object key)
            : base($"{name} with ({key}) was not found.")
        {

        }
       
        public NotFoundException(string extendedMessage)
            : base(extendedMessage)
        {
        }
    }
}
