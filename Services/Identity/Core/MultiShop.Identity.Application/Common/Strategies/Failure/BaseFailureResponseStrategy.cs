

namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public abstract class BaseFailureResponseStrategy : IFailureResponseStrategy
    {
        public abstract int Priority { get; }
        public abstract bool CanHandle<TResponse>();
        public abstract TResponse CreateFailure<TResponse>(string errorMessage);

        protected Type GetResponseType<TResponse>() => typeof(TResponse);
    }
}
