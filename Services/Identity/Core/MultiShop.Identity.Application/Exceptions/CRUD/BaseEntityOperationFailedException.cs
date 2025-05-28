namespace MultiShop.Identity.Application.Exceptions.CRUD
{
    public class BaseEntityOperationFailedException:Exception
    {

        public string EntityClassName { get; set; }
        public BaseEntityOperationFailedException()
        {
        }

        public BaseEntityOperationFailedException(string entityClassName) : base($"{entityClassName} entity could not made operation on db")
        {
            EntityClassName = entityClassName;
        }

        public BaseEntityOperationFailedException(string entityClassName, Exception innerException)
         : base($"{entityClassName} entity could not made operation and  actual error:{innerException.Message} ", innerException)
        {
            EntityClassName = entityClassName;
        }
    }
}
