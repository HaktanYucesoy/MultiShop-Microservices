using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces.Logging
{
    public interface IFileLogHandler:ILogHandler
    {
        Task SetFilePathAsync(string filePath);
        Task ArchiveLogsAsync(DateTime olderThan);
    }
}
