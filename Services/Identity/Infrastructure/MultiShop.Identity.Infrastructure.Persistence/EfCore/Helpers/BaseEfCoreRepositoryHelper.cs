using MultiShop.Identity.Application.Exceptions.CRUD;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Helpers
{
    public static class BaseEfCoreRepositoryHelper
    {
        public static void ExecuteWithExceptionHandling(Action action,BaseEntityOperationFailedException exception)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                throw exception;
            }
        }

        public static async Task ExecuteWithExceptionHandlingAsync(Func<Task> action,BaseEntityOperationFailedException exception)
        {
            try
            {
                await action();
            }
            catch (Exception)
            {
                throw exception;
            }
        }
    }
}
