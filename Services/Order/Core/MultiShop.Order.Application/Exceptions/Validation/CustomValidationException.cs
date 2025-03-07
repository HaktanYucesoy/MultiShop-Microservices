namespace MultiShop.Order.Application.Exceptions.Validation
{
    public class CustomValidationException:Exception
    {

        public CustomValidationException(IReadOnlyCollection<ValidationError> errors):
            base("Validation fail")
        {

        }

        public CustomValidationException(ValidationError error):base("Validation Fail")
        {

        }
    }


    public record ValidationError(string ErrorMessage,string PropertyName) { }
}
