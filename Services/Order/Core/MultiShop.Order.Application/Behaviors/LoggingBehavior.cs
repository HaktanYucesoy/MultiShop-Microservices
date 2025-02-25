using MediatR;
using MultiShop.Order.Application.Interfaces.Logging;
using System.Text.Json;

namespace MultiShop.Order.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>

    {
        private readonly ILoggerService _logger;

        public LoggingBehavior(ILoggerService logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestTypeName = typeof(TRequest).Name;
            try
            {
                var additionalData = new Dictionary<string, object>
                {
                  { "RequestType", requestTypeName },
                  { "RequestData", JsonSerializer.Serialize(request) }
                };

                await _logger.LogInformationAsync(
                    message: $"Processing request: {requestTypeName}",
                    methodName: $"{requestTypeName}.Handle",
                    additionalData: additionalData
                );

                var response = await next();

                await _logger.LogInformationAsync(
                    message: $"Request processed successfully: {requestTypeName}",
                    methodName: $"{requestTypeName}.Handle",
                    additionalData: new Dictionary<string, object>
                    {
                    { "ResponseData", JsonSerializer.Serialize(response) }
                    }
                );

                return response;
            }
            catch (Exception ex)
            {
                await _logger.LogErrorAsync(message: $"Error processing request: {requestTypeName}",exception: ex,methodName: $"{requestTypeName}.Handle",
                    additionalData: new Dictionary<string, object>{
                    { "RequestType", requestTypeName },
                    { "RequestData", JsonSerializer.Serialize(request) }
                    }
                );
                throw;
            }
        }
    }
}
