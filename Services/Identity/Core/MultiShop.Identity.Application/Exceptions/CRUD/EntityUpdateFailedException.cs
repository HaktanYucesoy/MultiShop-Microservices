namespace MultiShop.Identity.Application.Exceptions.CRUD
{
    public class EntityUpdateFailedException:BaseEntityOperationFailedException
    {
        public EntityUpdateFailedException()
        {
        }

        public EntityUpdateFailedException(string entityClassName) : base($"{entityClassName} entity could not updated")
        {
        }

        public EntityUpdateFailedException(string entityClassName, Exception innerException)
         : base($"{entityClassName} entity could not updated and actual error:{innerException.Message} ", innerException)
        {
        }
    }
}
