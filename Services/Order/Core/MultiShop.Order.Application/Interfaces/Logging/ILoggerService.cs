
namespace MultiShop.Order.Application.Interfaces.Logging
{
    public interface ILoggerService
    {
        Task LogInformationAsync(string message,string methodName, IDictionary<string, object> additionalData = null!);
        Task LogWarningAsync(string message,string methodName, IDictionary<string, object> additionalData = null!);
        Task LogErrorAsync(string message,string methodName, Exception exception = null!, IDictionary<string, object> additionalData = null!);
        Task LogDebugAsync(string message,string methodName, IDictionary<string, object> additionalData = null!);
    }
}
