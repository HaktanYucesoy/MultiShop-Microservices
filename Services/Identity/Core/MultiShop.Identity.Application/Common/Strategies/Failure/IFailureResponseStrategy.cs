

namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public interface IFailureResponseStrategy
    {
        bool CanHandle<TResponse>();

        TResponse CreateFailure<TResponse>(string errorMessage);

        int Priority { get; }
    }
}
