
namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public class DefaultFailureResponseStrategy : BaseFailureResponseStrategy
    {
        public override int Priority => 999;


        public override bool CanHandle<TResponse>()
        {
            return true;
        }

        public override TResponse CreateFailure<TResponse>(string errorMessage)
        {
            try
            {
                var responseType = typeof(TResponse);
                return (TResponse)Activator.CreateInstance(responseType)!;
            }
            catch
            {
                return default(TResponse)!;
            }
        }
    }
}
