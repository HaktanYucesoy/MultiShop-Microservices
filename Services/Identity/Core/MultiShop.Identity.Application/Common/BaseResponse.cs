namespace MultiShop.Identity.Application.Common
{
    public class BaseResponse : IResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }


        protected BaseResponse()
        {
            IsSuccess = true;
        }

        public static T CreateFailure<T>(string message=null) where T : BaseResponse, new()
        {
            return new T()
            {
                ErrorMessage = message,
                IsSuccess = false
            };
        }

        public static T CreateSuccess<T>() where T : BaseResponse, new()
        {
            return new T()
            {
                IsSuccess = true,
                ErrorMessage = null
            };
        }
    }
}
