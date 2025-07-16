
namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public class BaseResponseFailureResponseStrategy : BaseFailureResponseStrategy
    {
        public override int Priority => 2;

        public override bool CanHandle<TResponse>()
        {
            return typeof(BaseResponse).IsAssignableFrom(typeof(TResponse));
        }

        public override TResponse CreateFailure<TResponse>(string errorMessage)
        {
            var responseType=typeof(BaseResponse);

            var method=typeof(BaseResponse)
                .GetMethod(nameof(BaseResponse.CreateFailure))!
                .MakeGenericMethod(responseType);


            return (TResponse)method.Invoke(null, new object[] { errorMessage })!;
        }
    }
}
