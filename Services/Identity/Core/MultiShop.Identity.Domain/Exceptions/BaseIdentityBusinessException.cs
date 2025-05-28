

namespace MultiShop.Identity.Domain.Exceptions
{
    public class BaseIdentityBusinessException:Exception
    {
        public BaseIdentityBusinessException()
        {
            
        }

        public BaseIdentityBusinessException(string message) : base(message)
        {

        }

        public BaseIdentityBusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
