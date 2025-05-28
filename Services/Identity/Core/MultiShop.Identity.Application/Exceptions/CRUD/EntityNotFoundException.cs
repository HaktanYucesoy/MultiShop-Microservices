namespace MultiShop.Identity.Application.Exceptions.CRUD
{
    public class EntityNotFoundException : BaseEntityOperationFailedException
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(string entityClassName, int entityId)
            : base($"Entity of type {entityClassName} with id {entityId} was not found")
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }

}
