using Dapper;
using Domain.IntegrationsCore.Entities.Auditing;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;
using System.Reflection;
using Domain.IntegrationsCore.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.IntegrationsCore.Repositorys
{
    public class LogRepository : ILogRepository
    {
        private readonly ISQLServerConnection _conn;

        public LogRepository(ISQLServerConnection conn) =>
        _conn = conn;

        public async Task<bool> LogInsert(Log log)
        {
            //try
            //{
                var recordsTable = CreateSystemDataTable("Records", new Record());
                var messagesTable = CreateSystemDataTable("Messages", new Message());

                foreach (var record in log.Records)
                {
                    var text = record.RecordText.Length > 8000 ? record.RecordText.Substring(0, 8000) : record.RecordText;

                    recordsTable.Rows.Add(record.FieldKeyValue, text, log.Execution);
                }

                foreach (var message in log.Messages)
                {
                    messagesTable.Rows.Add(message.IdStage, message.IdLogLevel, message.IsError, message.IdError, message.Execution, message.Msg, message.ExceptionMessage, message.CommandSQL);
                }

                using (var conn = _conn.GetDbConnection())
                {
                    await conn.ExecuteAsync(
                            //sql: @$"INSERT INTO [auditing].[Logs] ([IdJob], [StartDate], [EndDate], [Execution])
                            //       VALUES ({(long)log.Job}, '{log.StartDate.ToString("s")}', '{log.EndDate.ToString("s")}', '{log.Execution}')",
                            sql: @$"INSERT INTO [GENERAL].[Logs] ([IdJob], [StartDate], [EndDate], [Execution])
                                   VALUES ({(long)log.Job}, '{log.StartDate.ToString("s")}', '{log.EndDate.ToString("s")}', '{log.Execution}')",
                            commandTimeout: 360
                        );

                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[auditing].[{recordsTable.TableName}]";
                    bulkCopy.BatchSize = recordsTable.Rows.Count;
                    bulkCopy.BulkCopyTimeout = 360;
                    foreach (DataColumn c in recordsTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    bulkCopy.WriteToServer(recordsTable);

                    bulkCopy.ColumnMappings.Clear();
                    bulkCopy.DestinationTableName = $"[auditing].[{messagesTable.TableName}]";
                    bulkCopy.BatchSize = messagesTable.Rows.Count;
                    bulkCopy.BulkCopyTimeout = 360;
                    foreach (DataColumn c in messagesTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    bulkCopy.WriteToServer(messagesTable);

                    return true;
                }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.InsertRecord,
            //        message: $"Error when trying to insert record in database table: [auditing].[Messages]",
            //        exceptionMessage: ex.Message,
            //        commandSQL: ""
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //    stage: EnumStages.InsertRecord,
            //    error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to insert record in database table: [auditing].[Messages]",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        private DataTable CreateSystemDataTable<TEntity>(string? tableName, TEntity entity)
        {
            try
            {
                var properties = entity.GetType().GetFilteredProperties();
                var dataTable = new DataTable(tableName);
                foreach (PropertyInfo prop in properties)
                {
                    dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.CreateSystemDataTable,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when convert system datatable to bulkinsert",
                    exceptionMessage: ex.Message
                );
            }
        }
    }
}
