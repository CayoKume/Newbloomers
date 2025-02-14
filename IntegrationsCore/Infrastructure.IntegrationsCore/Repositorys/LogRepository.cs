using Dapper;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Errors;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data.SqlClient;

namespace Infrastructure.IntegrationsCore.Repositorys
{
    public class LogRepository : ILogRepository
    {
        private readonly ISQLServerConnection _conn;

        public LogRepository(ISQLServerConnection conn) =>
        _conn = conn;

        public async Task<bool> LogInsert(Log log)
        {
            try
            {
                using (var conn = _conn.GetIDbConnection("NEWBLOOMERS"))
                {
                    await conn.ExecuteAsync(
                            sql: @$"INSERT INTO [auditing].[Logs] ([IdJob], [StartDate], [EndDate], [Execution])
                                   VALUES ({(Int64)log.Job}, '{log.StartDate.ToString("s")}', '{log.EndDate.ToString("s")}', '{log.Execution}')",
                            commandTimeout: 360
                        );

                    foreach (var record in log.Records)
                    {
                        var text = record.RegText.Length > 8000 ? record.RegText.Substring(0, 8000) : record.RegText;

                        await conn.ExecuteAsync(
                            sql: @$"INSERT INTO [auditing].[Records] ([FieldKeyValue], [RecordText], [Execution])
                                   VALUES ('{record.FieldKeyValue}', '{text}', '{log.Execution}')",
                            commandTimeout: 360
                        );
                    }

                    foreach (var message in log.Messages)
                    {
                        await conn.ExecuteAsync(
                            sql: @"INSERT INTO [auditing].[Messages] ([IdStage], [IdLogLevel], [IsError], [IdError], [Execution], [Message], [ExceptionMessage], [CommandSQL])
                                   VALUES (@IdStage, @IdLogLevel, @IsError, @IdError, @Execution, @Msg, @ExceptionMessage, @CommandSQL)",
                            param: message,
                            commandTimeout: 360
                        );
                    }
                    
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.InsertRecord,
                    message: $"Error when trying to insert record in database table: [auditing].[Messages]",
                    exceptionMessage: ex.Message,
                    commandSQL: ""
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                stage: EnumStages.InsertRecord,
                error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to insert record in database table: [auditing].[Messages]",
                    exceptionMessage: ex.Message
                );
            }
        }
    }
}
