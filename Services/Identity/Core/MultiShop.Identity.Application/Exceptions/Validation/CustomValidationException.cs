namespace MultiShop.Identity.Application.Exceptions.Validation
{
    public class CustomValidationException:Exception
    {
        public IReadOnlyCollection<ValidationError> validationErrors;

        public CustomValidationException(IReadOnlyCollection<ValidationError> errors) :
          base("Validation failed")
        {
            validationErrors = errors;
        }
    }

    public record ValidationError(string errorMessage,string propertyName);
}
