namespace MultiShop.Identity.Application.Exceptions.CRUD
{
    public class EntityDeleteFailedException:BaseEntityOperationFailedException
    {
        public EntityDeleteFailedException()
        {
        }

        public EntityDeleteFailedException(string entityClassName) : base($"{entityClassName} entity could not deleted from db")
        {
        }

        public EntityDeleteFailedException(string entityClassName, Exception innerException)
         : base($"{entityClassName} entity could not deleted from db and  actual error:{innerException.Message} ", innerException)
        {
        }
    }
}
