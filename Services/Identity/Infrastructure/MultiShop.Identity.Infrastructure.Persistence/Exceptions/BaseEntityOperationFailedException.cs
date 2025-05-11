

namespace MultiShop.Identity.Infrastructure.Persistence.Exceptions
{
    public class BaseEntityOperationFailedException:Exception
    {

        public string EntityClassName { get; set; }
        public BaseEntityOperationFailedException()
        {
        }

        public BaseEntityOperationFailedException(string entityClassName) : base($"{entityClassName} entity could not made operation on db")
        {
            this.EntityClassName = entityClassName;
        }

        public BaseEntityOperationFailedException(string entityClassName, Exception innerException)
         : base($"{entityClassName} entity could not made operation and  actual error:{innerException.Message} ", innerException)
        {
            this.EntityClassName = entityClassName;
        }
    }
}
