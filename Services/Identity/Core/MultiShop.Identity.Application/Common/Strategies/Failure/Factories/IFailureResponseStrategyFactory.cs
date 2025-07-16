

namespace MultiShop.Identity.Application.Common.Strategies.Failure.Factories
{
    public interface IFailureResponseStrategyFactory
    {
        IFailureResponseStrategy GetFailureResponseStrategy<TResponse>();

        TResponse CreateFailureResponseStrategic<TResponse>(string errorMessage);
    }
}
