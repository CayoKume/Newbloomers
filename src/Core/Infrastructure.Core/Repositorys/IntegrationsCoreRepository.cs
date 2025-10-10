using Dapper;
using Domain.Core.Entities.Auditing;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Extensions;
using Domain.Core.Interfaces;
using Infrastructure.Core.Connections.SQLServer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using static Dapper.SqlMapper;

namespace Infrastructure.Core.Repositorys
{
    public class CoreRepository : ICoreRepository 
    {
        private readonly ISQLServerConnection _sqlServerConnection;

        public CoreRepository(ISQLServerConnection sqlServerConnection) =>
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
                throw new GeneralException(
                    message: $"Error when trying to bulk insert records on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public bool BulkInsertIntoTableRaw(DataTable dataTable, string schema)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[{schema}].[{dataTable.TableName}]";
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
                throw new GeneralException(
                    message: $"Error when trying to bulk insert records on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        //Refatorar Aqui (criar BulkInsertIntoTableRaw com schemaName e adicionar FillSystemDataTable como parte do corpo principal do método, após refatoração matar os 3 métodos)
        public bool BulkInsertIntoTableRaw<TEntity>(List<TEntity> recordsList, TEntity entity, string tableName /*,string schemaName*/)
        {
            try
            {
                var table = CreateSystemDataTable(tableName, entity);

                /*var properties = data.FirstOrDefault().GetType().GetFilteredProperties();

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
                }*/
                FillSystemDataTable(table, recordsList.ToList());

                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[linx_microvix].[{table.TableName}]";
                    bulkCopy.BatchSize = table.Rows.Count;
                    bulkCopy.BulkCopyTimeout = 360;
                    foreach (DataColumn c in table.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    bulkCopy.WriteToServer(table);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error trying to create system datatable - {ex.Message}",
                    exceptionMessage: ex.StackTrace
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
                throw new GeneralException(
                    message: $"error trying to create system datatable - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public void FillSystemDataTable<TEntity>(DataTable dataTable, List<TEntity> data)
        {
            try
            {
                if (data.Count() > 0)
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
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to fill the system datatable - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ParentExecutionGUID", parentExecutionGUID);

                    var result = await conn.ExecuteAsync($"[{schemaName}].[P_{tableName}_Sincronizacao]", param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: 2700);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to run sync proc on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> CallDbProcMerge(string schemaName, string tableName)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync($"[{schemaName}].[P_{tableName}_Sincronizacao]", commandType: CommandType.StoredProcedure, commandTimeout: 2700);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to run sync proc on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> LogInsert(Log log)
        {
            var recordsTable = CreateSystemDataTable("Records", new Record());
            var messagesTable = CreateSystemDataTable("Messages", new Message());

            //adicionar FillSystemDataTable
            foreach (var record in log.Records)
            {
                //adicionar fluent validations
                var text = record.RecordText?.Length > 8000 ? record.RecordText?.Substring(0, 8000) : record.RecordText;

                recordsTable.Rows.Add(record.FieldKeyValue, text, log.Execution);
            }

            //adicionar FillSystemDataTable
            foreach (var message in log.Messages)
            {
                messagesTable.Rows.Add(message.IdStage, message.IdLogLevel, message.IsError, message.IdError, message.Execution, message.Msg, message.ExceptionMessage, message.ExceptionMessage);
            }

            await ExecuteCommand(@$"INSERT INTO [auditing].[Logs] ([IdJob], [StartDate], [EndDate], [Execution])
                            VALUES ({(long)log.Job}, '{log.StartDate.ToString("s")}', '{log.EndDate.ToString("s")}', '{log.Execution}')");

            BulkInsertIntoTableRaw(recordsTable, "auditing");

            BulkInsertIntoTableRaw(messagesTable, "auditing");

            return true;
        }

        public async Task<TEntity?> GetRecord<TEntity>(string? sql)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    return await conn.QueryFirstOrDefaultAsync<TEntity?>(sql: sql, commandTimeout: 360);
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"Error when trying to get record from database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"Error when trying to get record from database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<IEnumerable<TEntity?>> GetRecords<TEntity>(string? sql)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    var result = await conn.QueryAsync<TEntity>(sql: sql, commandTimeout: 360);
                    return result.ToList();
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"Error when trying to get records from database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"Error when trying to get records from database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> InsertRecord(string? sql, object entity)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: entity, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"Error when trying to insert record on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"Error when trying to insert record on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> ExecuteCommand(string? sql)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 3600);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> ExecuteCommand(string? sql, object entity)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, entity, commandTimeout: 3600);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> ExecuteCommand(string? sql, DynamicParameters parameters)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: parameters, commandTimeout: 3600);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }

        public async Task<bool> ExecuteCommand(string? sql, DynamicParameters parameters, CommandType commandType)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: parameters, commandType: commandType, commandTimeout: 3600);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    message: $"error when trying to execute sql command on database - {ex.Message}",
                    exceptionMessage: ex.StackTrace
                );
            }
        }
    }
}
