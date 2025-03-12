
namespace MultiShop.Order.Application.Exceptions.Common
{
    public class BusinessException:Exception
    {
        public BusinessException()
        {
            
        }

        public BusinessException(string? message) : base(message)
        {

        }
    }
}
