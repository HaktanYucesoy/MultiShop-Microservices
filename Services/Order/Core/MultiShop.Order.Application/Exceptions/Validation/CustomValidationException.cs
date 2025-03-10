namespace MultiShop.Order.Application.Exceptions.Validation
{
    public class CustomValidationException:Exception
    {
        public IReadOnlyCollection<ValidationError> Errors { get; set; }
        public CustomValidationException(IReadOnlyCollection<ValidationError> errors):
            base("Validation fail")
        {
            this.Errors = errors;
        }
    }


    public record ValidationError(string ErrorMessage,string PropertyName) { }
}
