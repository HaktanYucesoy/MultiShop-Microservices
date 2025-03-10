using FluentValidation;
using MediatR;
using MultiShop.Order.Application.Exceptions.Validation;

namespace MultiShop.Order.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context=new ValidationContext<TRequest>(request);
            var errors= _validators
                .Select(v => v.Validate(context))
                .Where(v=>!v.IsValid)
                .SelectMany(result => result.Errors)
                .Select(validationFailure=>new ValidationError(validationFailure.PropertyName,validationFailure.ErrorMessage)).ToList();

            if (errors.Any())
            {
               
                throw new CustomValidationException(errors);
                
               
            }

            var response = await next();
            return response;
        }
    }
}
