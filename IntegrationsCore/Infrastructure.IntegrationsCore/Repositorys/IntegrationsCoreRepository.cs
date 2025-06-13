using Dapper;
using Domain.IntegrationsCore.Models.Errors;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Models.Exceptions;
using Domain.IntegrationsCore.Extensions;
using Domain.IntegrationsCore.Interfaces;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Infrastructure.IntegrationsCore.Repositorys
{
    public class IntegrationsCoreRepository : IIntegrationsCoreRepository
    {
        private readonly ISQLServerConnection _sqlServerConnection;

        public IntegrationsCoreRepository(ISQLServerConnection sqlServerConnection) =>
            _sqlServerConnection = sqlServerConnection;

        public bool BulkInsertIntoTableRaw(DataTable dataTable)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[untreated].[{dataTable.TableName}]";
                    bulkCopy.BatchSize = dataTable.Rows.Count;
                    bulkCopy.BulkCopyTimeout = 360;
                    foreach (DataColumn c in dataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    bulkCopy.WriteToServer(dataTable);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.BulkInsertIntoTableRaw,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to bulk insert records on table raw",
                    exceptionMessage: ex.Message
                );
            }
        }

        public DataTable CreateSystemDataTable<TEntity>(string? tableName, TEntity entity)
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

        public void FillSystemDataTable<TEntity>(DataTable dataTable, List<TEntity> data)
        {
            try
            {
                var properties = data.FirstOrDefault().GetType().GetFilteredProperties();

                foreach (var item in data)
                {
                    var rowValues = new object[properties.Length];

                    for (int i = 0; i < properties.Length; i++)
                    {
                        var prop = properties[i];
                        var value = prop.GetValue(item);

                        rowValues[i] = value ?? DBNull.Value;
                    }

                    dataTable.Rows.Add(rowValues);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> LogInsert(Log log)
        {
            try
            {
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

                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    await conn.ExecuteAsync(
                            sql: @$"INSERT INTO [auditing].[Logs] ([IdJob], [StartDate], [EndDate], [Execution])
                                   VALUES ({(long)log.Job}, '{log.StartDate.ToString("s")}', '{log.EndDate.ToString("s")}', '{log.Execution}')",
                            commandTimeout: 360
                        );

                    BulkInsertIntoTableRaw(recordsTable);

                    BulkInsertIntoTableRaw(messagesTable);

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
