using Dapper;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using System.Data;
using Z.Dapper.Plus;
using Microsoft.Extensions.Configuration;
using Domain.IntegrationsCore.Entities.Parameters;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Infrastructure.IntegrationsCore.Connections.MySQL;
using Infrastructure.IntegrationsCore.Connections.PostgreSQL;
using static Domain.IntegrationsCore.Exceptions.InternalErrorsExceptions;
using System.Data.SqlClient;
using System.ComponentModel;
using static Domain.IntegrationsCore.Exceptions.RepositorysExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base
{
    public class LinxMicrovixRepositoryBase<TEntity> : ILinxMicrovixRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly string? _parametersTableName;

        private readonly IConfiguration _configuration;
        private readonly ISQLServerConnection? _sqlServerConnection;
        private readonly IMySQLConnection? _mySQLConnection;
        private readonly IPostgreSQLConnection? _postgreSQLConnection;

        public LinxMicrovixRepositoryBase(
            ISQLServerConnection sqlServerConnection, 
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _sqlServerConnection = sqlServerConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxMicrovix")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public LinxMicrovixRepositoryBase(
            IMySQLConnection mySQLConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _mySQLConnection = mySQLConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxMicrovix")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public LinxMicrovixRepositoryBase(
            IPostgreSQLConnection postgreSQLConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _postgreSQLConnection = postgreSQLConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxMicrovix")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public async Task<bool> CallDbProcMerge(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync($"P_{jobParameter.tableName}_Sync", commandType: CommandType.StoredProcedure, commandTimeout: 2700);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteWithoutCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"CallDbProcMerge",
                    message = $"Error when trying to run the merge procedure: P_{jobParameter.tableName}_Sync",
                    schema = $"{jobParameter.tableName}",
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobParameter.tableName}_raw' OR TABLE_NAME = '{jobParameter.tableName}_trusted'";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.CreateTable<TEntity>(tableName: $"{jobParameter.tableName}_raw");
                        conn.CreateTable<TEntity>(tableName: $"{jobParameter.tableName}_trusted");

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"CreateDataTableIfNotExists",
                    message = $"Error when trying to create table: {jobParameter.tableName}",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public DataTable CreateSystemDataTable(LinxMicrovixJobParameter jobParameter, TEntity entity)
        {
            try
            {
                var properties = TypeDescriptor.GetProperties(typeof(TEntity));
                var dataTable = new DataTable(jobParameter.tableName);
                foreach (PropertyDescriptor prop in properties)
                {
                    dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new InternalErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = "CreateSystemDataTable",
                    message = $"Error when convert system datatable to bulkinsert",
                    record = $" - ",
                    propertie = " - ",
                    exception = ex.Message
                };
            }
        }

        public async Task<List<TEntity>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, string? sql)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync<TEntity>(sql: sql, commandTimeout: 360);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ObjectsNotFoundExcpetion()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"GetRegistersExists",
                    message = $"Error when trying to get allready exists registers from database",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<IEnumerable<Company>> GetB2CCompanys(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"SELECT  
                           EMPRESA AS COD_COMPANY,
                           CNPJ_EMP AS DOC_COMPANY,
                           NOME_EMP AS REASON_COMPANY,
                           NOME_EMP AS NAME_COMPANY,
                           EMAIL_UNIDADE AS EMAIL_COMPANY,
                           END_UNIDADE AS ADDRESS_COMPANY,
                           NR_RUA_UNIDADE AS STREET_NUMBER_COMPANY,
                           COMPLEMENTO_END_UNIDADE AS COMPLEMENT_ADDRESS_COMPANY,
                           BAIRRO_UNIDADE AS NEIGHBORHOOD_COMPANY,
                           CIDADE_UNIDADE AS CITY_COMPANY,
                           UF_UNIDADE AS UF_COMPANY,
                           CEP_UNIDADE AS ZIP_CODE_COMPANY,
                           '' AS FONE_COMPANY,
                           '' AS STATE_REGISTRATION_COMPANY,
                           '' AS MUNICIPAL_REGISTRATION_COMPANY
                           FROM 
                           B2CCONSULTAEMPRESAS_TRUSTED (NOLOCK)";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    return await conn.QueryAsync<Company>(sql: sql);
                }
            }
            catch (Exception ex)
            {
                throw new ObjectsNotFoundExcpetion()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"GetCompanys",
                    message = $"Error when trying to get companys from database",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<IEnumerable<Company>> GetMicrovixCompanys(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    return await conn.QueryAsync<Company>(sql: sql);
                }
            }
            catch (Exception ex)
            {
                throw new ObjectsNotFoundExcpetion()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"GetCompanys",
                    message = $"Error when trying to get companys from database",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<string?> GetParameters(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = $"SELECT {jobParameter.parametersInterval} " +
                         $"FROM [{jobParameter.parametersTableName}] (NOLOCK) " +
                          "WHERE " +
                         $"METHOD = '{jobParameter.jobName}'";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
                }
            }
            catch (Exception ex)
            {
                throw new ObjectsNotFoundExcpetion()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"GetParameters",
                    message = $"Error when trying to get parameters from database",
                    schema = $"[{jobParameter.parametersTableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<string?> GetLast7DaysMinTimestamp(LinxMicrovixJobParameter jobParameter, string? columnDate)
        {
            string? sql = "SELECT ISNULL(MIN(TIMESTAMP), 0) " +
                         $"FROM [{jobParameter.tableName}_trusted] (NOLOCK) " +
                          "WHERE " +
                         $"{columnDate} > GETDATE() - 7";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
                }
            }
            catch (Exception ex)
            {
                throw new ObjectsNotFoundExcpetion()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"GetLast7DaysMinTimestamp",
                    message = $"Error when trying to get last timestamp from database",
                    schema = $"[{jobParameter.parametersTableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, string? sql, object record)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: record, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"InsertRecord",
                    message = $"Error when trying to insert record in database table: {jobParameter.tableName}",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter, object parameter)
        {
            string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                         $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual], [ativo]) " +
                          "VALUES (@method, @parameters_timestamp, @parameters_dateinterval, @parameters_individual, @ativo)";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: parameter, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"InsertRecord",
                    message = $"Error when trying to insert record in database table: {jobParameter.tableName}",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> InsertLogResponse(LinxMicrovixJobParameter jobParameter, string? response, object record)
        {
            string? sql = $"INSERT INTO {jobParameter.parametersLogTableName} " +
              "([method], [execution_date], [parameters_interval], [response]) " +
              "Values " +
              "(@method, GETDATE(), @parameters_interval, @response)";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: record, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"InsertRecord",
                    message = $"Error when trying to insert record in database table: {jobParameter.tableName}",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> UpdateLogParameters(LinxMicrovixJobParameter jobParameter, string? lastResponse)
        {
            string? sql = $"UPDATE {jobParameter.parametersTableName} " +
                          "SET LAST_EXECUTION = GETDATE(), " +
                         $"LAST_RESPONSE = '{lastResponse}' " +
                          "WHERE " +
                         $"METHOD = '{jobParameter.jobName}'";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"UpdateLogParameters",
                    message = $"Error when trying to update date of last execution date in database table: {jobParameter.parametersLogTableName}",
                    schema = $"[{jobParameter.parametersLogTableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> ExecuteQueryCommand(LinxMicrovixJobParameter jobParameter, string? sql)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"ExecuteQueryCommand",
                    message = $"Error when trying to execute command sql",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> DeleteLogResponse(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = $"DELETE FROM [{jobParameter.parametersLogTableName}] " +
                         $"WHERE METHOD = '{jobParameter.jobName}' " +
                         $"AND ID NOT IN (SELECT TOP 15 ID FROM [{jobParameter.parametersLogTableName}] ORDER BY ID DESC)";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"DeleteLogResponse",
                    message = $"Error when trying to clear parameters log table",
                    schema = $"[{jobParameter.tableName}]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public async Task<bool> ExecuteTruncateRawTable(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = $"TRUNCATE TABLE [{jobParameter.tableName}_raw]";

            try
            {
                using (var conn = _sqlServerConnection.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"ExecuteTruncateRawTable",
                    message = $"Error when trying to truncate table raw",
                    schema = $"[{jobParameter.tableName}_raw]",
                    command = sql,
                    exception = ex.Message
                };
            }
        }

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, DataTable dataTable, int dataTableRowsNumber)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetDbConnection(jobParameter.databaseName))
                {
                    using var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = $"[{jobParameter.tableName}_raw]";
                    bulkCopy.BatchSize = dataTableRowsNumber;
                    bulkCopy.BulkCopyTimeout = 360;
                    bulkCopy.WriteToServer(dataTable);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ExecuteCommandException()
                {
                    project = $"{jobParameter.projectName} - IntegrationsCore",
                    job = jobParameter.jobName,
                    method = $"BulkInsertIntoTableRaw",
                    message = $"Error when trying to bulk insert records on table raw",
                    schema = $"[{jobParameter.tableName}_raw]",
                    command = " - ",
                    exception = ex.Message
                };
            }
        }
    }
}
