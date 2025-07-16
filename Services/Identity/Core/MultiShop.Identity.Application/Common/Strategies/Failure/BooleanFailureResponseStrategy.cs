

namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public class BooleanFailureResponseStrategy : BaseFailureResponseStrategy
    {
        public override int Priority => 4;

        public override bool CanHandle<TResponse>()
        {
            return typeof(TResponse) == typeof(bool);
        }

        public override TResponse CreateFailure<TResponse>(string errorMessage)
        {
            return (TResponse)(object)false;
        }
    }
}
