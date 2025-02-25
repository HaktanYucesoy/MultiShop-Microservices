using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace MultiShop.Order.Infrastructure.Logging.Serilog.Factory
{
    public class MsSqlServerSinkFactory:ISerilogSinkFactory
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public MsSqlServerSinkFactory(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        public LoggerConfiguration ConfigureSink(LoggerConfiguration loggerConfiguration)
        {
            var sinkOptions = new MSSqlServerSinkOptions
            {
                TableName = _tableName,
                AutoCreateSqlTable = true
            };

            var columnOptions = new ColumnOptions();

            return loggerConfiguration.WriteTo.MSSqlServer(
                connectionString: _connectionString,
                sinkOptions: sinkOptions,
                columnOptions: columnOptions
            );
        }
    }
}
