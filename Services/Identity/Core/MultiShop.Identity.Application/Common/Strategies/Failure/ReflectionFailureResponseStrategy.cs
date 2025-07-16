

namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public class ReflectionFailureResponseStrategy : BaseFailureResponseStrategy
    {
        public override int Priority => 3;

        public override bool CanHandle<TResponse>()
        {
            var responseType= typeof(TResponse);
            return responseType.GetProperty("IsSuccess") != null;
        }

        public override TResponse CreateFailure<TResponse>(string errorMessage)
        {
            var responseType = typeof(TResponse);
            var instance = (TResponse)Activator.CreateInstance(responseType)!;
            var isSuccessProperty = responseType.GetProperty("IsSuccess");
            isSuccessProperty?.SetValue(instance, false);


            var errorMessageProperty = responseType.GetProperty("ErrorMessage")
                ?? responseType.GetProperty("Message")
                ?? responseType.GetProperty("Error");

            errorMessageProperty?.SetValue(instance, errorMessage);

            return instance;

        }
    }
}
