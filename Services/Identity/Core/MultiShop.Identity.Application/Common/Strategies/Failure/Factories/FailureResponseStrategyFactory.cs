
namespace MultiShop.Identity.Application.Common.Strategies.Failure.Factories
{
    public class FailureResponseStrategyFactory : IFailureResponseStrategyFactory
    { 
        private readonly IReadOnlyList<IFailureResponseStrategy> _responseStrategies;
        public FailureResponseStrategyFactory(IEnumerable<IFailureResponseStrategy> responseStrategies)
        {
            _responseStrategies=responseStrategies.OrderBy(s=>s.Priority).ToList();
        }
        public TResponse CreateFailureResponseStrategic<TResponse>(string errorMessage)
        {
            var strategy = GetFailureResponseStrategy<TResponse>();
            return strategy.CreateFailure<TResponse>(errorMessage);
        }

        public IFailureResponseStrategy GetFailureResponseStrategy<TResponse>()
        {
            foreach (var responseStrategy in _responseStrategies)
            {
                if (responseStrategy.CanHandle<TResponse>())
                {
                    return responseStrategy;
                }
            }

            throw new InvalidOperationException($"No strategy found for response type {typeof(TResponse).Name}");
        }
    }
}
