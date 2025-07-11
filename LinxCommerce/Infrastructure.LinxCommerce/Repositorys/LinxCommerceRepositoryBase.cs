using Dapper;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Extensions;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys;
using Infrastructure.IntegrationsCore.Connections.MySQL;
using Infrastructure.IntegrationsCore.Connections.PostgreSQL;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Infrastructure.LinxCommerce.Repositorys
{
    public class LinxCommerceRepositoryBase : ILinxCommerceRepositoryBase
    {
        private readonly string? _parametersTableName;

        private readonly IConfiguration _configuration;
        private readonly ISQLServerConnection? _sqlServerConnection;
        private readonly IMySQLConnection? _mySQLConnection;
        private readonly IPostgreSQLConnection? _postgreSQLConnection;

        public LinxCommerceRepositoryBase(
            ISQLServerConnection sqlServerConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _sqlServerConnection = sqlServerConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxCommerce")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public LinxCommerceRepositoryBase(
            IMySQLConnection mySQLConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _mySQLConnection = mySQLConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxCommerce")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public LinxCommerceRepositoryBase(
            IPostgreSQLConnection postgreSQLConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _postgreSQLConnection = postgreSQLConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxCommerce")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public bool BulkInsertIntoTableRaw(string? jobName, string? dataTableName, string? databaseName, DataTable dataTable, int dataTableRowsNumber)
        {
            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[untreated].[{dataTableName}]";
                    //bulkCopy.DestinationTableName = $"[linx_commerce].[{dataTableName}]";
                    bulkCopy.BatchSize = dataTableRowsNumber;
                    bulkCopy.BulkCopyTimeout = 360;
                    foreach (DataColumn c in dataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    bulkCopy.WriteToServer(dataTable);
                }

                return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.BulkInsertIntoTableRaw,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to bulk insert records on table raw",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public bool BulkInsertIntoTableTrusted(string? jobName, string? dataTableName, string? databaseName, DataTable dataTable, int dataTableRowsNumber)
        {
            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[linx_commerce].[{dataTableName}]";
                    bulkCopy.BatchSize = dataTableRowsNumber;
                    bulkCopy.BulkCopyTimeout = 360;
                    foreach (DataColumn c in dataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    bulkCopy.WriteToServer(dataTable);
                }

                return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.BulkInsertIntoTableRaw,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to bulk insert records on table raw",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<bool> CallDbProcMerge(LinxCommerceJobParameter jobParameter)
        {
            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    var result = await conn.ExecuteAsync($"P_{jobParameter.tableName}_Sync", commandType: CommandType.StoredProcedure, commandTimeout: 2700);

                    if (result > 0)
                        return true;

                    return false;
                }
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.CallDbProcMerge,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to run the merge procedure: P_{jobParameter.tableName}_Sync",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID)
        {
            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ParentExecutionGUID", parentExecutionGUID);

                    var result = await conn.ExecuteAsync($"[{schemaName}].[P_{tableName}_Sincronizacao]", param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: 2700);

                    if (result > 0)
                        return true;

                    return false;
                }
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.CallDbProcMerge,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to run the merge procedure: P_{tableName}_Sincronizacao",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<bool> ExecuteQueryCommand(LinxCommerceJobParameter jobParameter, string? sql)
        {
            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        //stage: EnumStages.ExecuteQueryCommand,
            //        message: $"Error when trying to execute command sql"//,
            //        //exceptionMessage: ex.Message//,
            //        //commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.ExecuteQueryCommand,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to execute command sql",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<string?> GetParameters(LinxCommerceJobParameter jobParameter)
        {
            string sql = $@"SELECT NUMBEROFDAYS FROM [BLOOMERS_LINX].[dbo].[LINXAPIPARAM] WHERE METHOD = '{jobParameter.tableName}'";

            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    return await conn.QueryFirstAsync<string>(sql: sql, commandTimeout: 360);
                }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        //stage: EnumStages.GetParameters,
            //        message: $"Error when trying to get parameters from database"//,
            //        //exceptionMessage: ex.Message//,
            //        //commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.GetParameters,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get parameters from database",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<bool> InsertRecord(LinxCommerceJobParameter jobParameter, string? sql, object record)
        {
            //try
            //{
                using (var conn = _sqlServerConnection.GetDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: record, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        //stage: EnumStages.InsertRecord,
            //        message: $"Error when trying to insert record in database table: {jobParameter.tableName}"//,
            //        //exceptionMessage: ex.Message//,
            //        //commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.InsertRecord,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when trying to insert record in database table: {jobParameter.tableName}",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity)
        {
            //try
            //{
                var properties = entity.GetType().GetFilteredProperties();
                var dataTable = new DataTable(jobParameter.tableName);
                foreach (PropertyInfo prop in properties)
                {
                    dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                return dataTable;
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.CreateSystemDataTable,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when convert system datatable to bulkinsert",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }

        public DataTable CreateSystemDataTable<TEntity>(LinxCommerceJobParameter jobParameter, TEntity entity, string[] columnNames, Type[] columnTypes)
        {
            //try
            //{
                var properties = entity.GetType().GetFilteredProperties();
                var dataTable = new DataTable(jobParameter.tableName);

                for (int i = 0; i < properties.Count(); i++)
                {
                    for (int j = 0; j < columnNames.Length; j++)
                    {
                        if (properties[i].Name == columnNames[j])
                            dataTable.Columns.Add(properties[i].Name, columnTypes[j]);

                        else if (!dataTable.Columns.Contains(properties[i].Name) && !columnNames.Contains(properties[i].Name))
                            dataTable.Columns.Add(properties[i].Name, Nullable.GetUnderlyingType(properties[i].PropertyType) ?? properties[i].PropertyType);
                    }
                }

                return dataTable;
            //}
            //catch (Exception ex)
            //{
            //    throw new GeneralException(
            //        //stage: EnumStages.CreateSystemDataTable,
            //        //error: EnumError.SQLCommand,
            //        //level: EnumMessageLevel.Error,
            //        message: $"Error when convert system datatable to bulkinsert",
            //        //exceptionMessage: ex.Message
            //    );
            //}
        }
    }
}
