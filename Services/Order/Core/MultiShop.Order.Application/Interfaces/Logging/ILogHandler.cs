
using MultiShop.Order.Application.Models.Logging;

namespace MultiShop.Order.Application.Interfaces.Logging
{
    public interface ILogHandler
    {
        Task HandleLogAsync(LogDetail logdetail);
    }
}
