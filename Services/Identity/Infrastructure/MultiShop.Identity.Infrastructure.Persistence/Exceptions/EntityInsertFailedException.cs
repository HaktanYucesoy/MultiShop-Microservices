namespace MultiShop.Identity.Infrastructure.Persistence.Exceptions
{
    
    public class EntityInsertFailedException : BaseEntityOperationFailedException
    {
        public EntityInsertFailedException()
        {
        }

        public EntityInsertFailedException(string entityClassName) : base($"{entityClassName} entity could not inserted to db")
        {
        }

        public EntityInsertFailedException(string entityClassName,Exception innerException)
         : base($"{entityClassName} entity could not inserted to db and actual error:{innerException.Message} ",innerException)
        {
        }
    }
}