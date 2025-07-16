

namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public class NullableFailureResponseStrategy : BaseFailureResponseStrategy
    {
        public override int Priority => 5;

        public override bool CanHandle<TResponse>()
        {
            var responseType= typeof(TResponse);
            return !responseType.IsValueType || Nullable.GetUnderlyingType(responseType) != null;
        }

        public override TResponse CreateFailure<TResponse>(string errorMessage)
        {
            return default(TResponse)!;
        }
    }
}
