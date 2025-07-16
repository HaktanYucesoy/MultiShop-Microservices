

namespace MultiShop.Identity.Application.Common.Strategies.Failure
{
    public class IResultFailureResponseStrategy : BaseFailureResponseStrategy
    {
        public override int Priority => 1;

        public override bool CanHandle<TResponse>()
        {
            return typeof(IResult).IsAssignableFrom(typeof(TResponse));
        }

        public override TResponse CreateFailure<TResponse>(string errorMessage)
        {
            var responseType=typeof(TResponse);
            var instance=(IResult)Activator.CreateInstance(responseType)!;
            instance.ErrorMessage=errorMessage;
            instance.IsSuccess = false;
            return (TResponse)instance;
        }
    }
}
