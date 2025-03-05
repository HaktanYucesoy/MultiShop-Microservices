using Microsoft.Data.SqlClient;
using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Interfaces.Logging.Strategies.Database;
using MultiShop.Order.Application.Models.Logging;
using System.Data;
using System.Text.Json;

namespace MultiShop.Order.Infrastructure.Logging.Strategies.Database
{
    public class MSSQLDbLogStorageStrategy : IRelationalDbLogStorageStrategy
    {

        private readonly string _connectionString;
        private readonly string _tableName;

        public MSSQLDbLogStorageStrategy(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        public string StorageType => "MSSQL";

        public IDbConnection CreateConnection(string connectionString)=>new SqlConnection(connectionString);

        public string GetConnectionString(string connectionString) => connectionString;

        public string GetInsertCommandText(string tableName)=> $"INSERT INTO {tableName} (TimeStamp, Level, Message, Exception, Properties) " +
        "VALUES (@TimeStamp, @Level, @Message, @Exception, @Properties)";
        public string GetProviderName()=>"Microsoft.Data.SqlClient.SqlConnection, Microsoft.Data.SqlClient";


        public async Task PurgeLogsAsync(DateTime olderThan)
        {
            await Task.Run(() =>
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"DELETE FROM {_tableName} WHERE TimeStamp < @OlderThan";
                        command.Parameters.Add(CreateParameter(command, "@OlderThan", olderThan));
                        command.ExecuteNonQuery();
                    }
                }
            });
        }

        public async Task<IList<LogDetail>> QueryLogsAsync(DateTime startDate, DateTime endDate, LogLevel? level = null)
        {
            List<LogDetail> results = new List<LogDetail>();

            await Task.Run(() =>
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    connection.Open();
                    var query = $"SELECT * FROM {_tableName} WHERE TimeStamp BETWEEN @StartDate AND @EndDate";
                    if (level.HasValue)
                    {
                        query += " AND Level = @Level";
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Parameters.Add(CreateParameter(command, "@StartDate", startDate));
                        command.Parameters.Add(CreateParameter(command, "@EndDate", endDate));
                        if (level.HasValue)
                        {
                            command.Parameters.Add(CreateParameter(command, "@Level", level.Value.ToString()));
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new LogDetail
                                {
                                    Timestamp = reader.GetDateTime(0),
                                    Level = Enum.Parse<LogLevel>(reader.GetString(1)),
                                    Message = reader.GetString(2),
                                    Exception = reader.IsDBNull(3) ? null! : new Exception(reader.GetString(3)),
                                    AdditionalData = JsonSerializer.Deserialize<IDictionary<string, object>>(reader.GetString(4))
                                });
                            }
                        }


                    }
                }

            });

            return results;
        }

        public async Task StoreLogAsync(LogDetail logDetail)
        {
            await Task.Run(() =>
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = GetInsertCommandText(_tableName);

                        var parameters = new[]
                        {
                            CreateParameter(command, "@TimeStamp", logDetail.Timestamp),
                            CreateParameter(command, "@Level", logDetail.Level.ToString()),
                            CreateParameter(command, "@Message", logDetail.Message),
                            CreateParameter(command, "@Exception", logDetail.Exception?.ToString()),
                            CreateParameter(command, "@Properties", JsonSerializer.Serialize  (logDetail.AdditionalData))
                        };

                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        command.ExecuteNonQuery();

                    }
                }
            });
          
        }


        private IDbDataParameter CreateParameter(IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            return parameter;
        }
    }
}
