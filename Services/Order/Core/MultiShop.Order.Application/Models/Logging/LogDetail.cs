using MultiShop.Order.Application.Enums;

namespace MultiShop.Order.Application.Models.Logging
{
    public class LogDetail
    {
        public string Message { get; set; }
        public LogLevel Level { get; set; }
        public DateTime Timestamp { get; set; }
        public Exception Exception { get; set; }
        public IDictionary<string, object>? AdditionalData { get; set; }
        public string? TraceId { get; set; }
        public string? MethodName { get; set; }
    }
}
