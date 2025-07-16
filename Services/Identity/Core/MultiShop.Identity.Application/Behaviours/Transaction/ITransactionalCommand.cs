

namespace MultiShop.Identity.Application.Behaviours.Transaction
{
    public interface ITransactionalCommand
    {

    }


    public interface ITransactionalCommand<TIsolationLevel> : ITransactionalCommand
    {

    }
}
