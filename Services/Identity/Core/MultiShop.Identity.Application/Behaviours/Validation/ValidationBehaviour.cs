using FluentValidation;
using MediatR;
using MultiShop.Identity.Application.Exceptions.Validation;

namespace MultiShop.Identity.Application.Behaviours.Validation
{
    public class ValidationBehaviour<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context=new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(v => v.Validate(context))
                .Where(v => !v.IsValid)
                .SelectMany(result => result.Errors)
                .Select(validationFailure => new ValidationError(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage))
                .ToList();


            if(errors.Any())
            {
                throw new CustomValidationException(errors);
            }

            var response = await next();
            return response;

        }
    }
}
