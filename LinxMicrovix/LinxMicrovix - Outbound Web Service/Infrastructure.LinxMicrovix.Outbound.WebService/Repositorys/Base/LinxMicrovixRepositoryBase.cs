using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Infrastructure.IntegrationsCore.Connections.PostgreSQL;
using Infrastructure.IntegrationsCore.Connections.MySQL;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Base;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Entities.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.Base
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
                throw new InternalException(
                    stage: EnumStages.CallDbProcMerge,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to run the merge procedure: P_{jobParameter.tableName}_Sync",
                    exceptionMessage: ex.Message
                );
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
                throw new InternalException(
                    stage: EnumStages.CreateSystemDataTable,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when convert system datatable to bulkinsert",
                    exceptionMessage: ex.Message
                );
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
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.GetParameters,
                    message: $"Error when trying to get companys from database",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetB2CCompanys,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to get companys from database",
                    exceptionMessage: ex.Message
                );
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
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.GetMicrovixCompanys,
                    message: $"Error when trying to get companys from database",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetMicrovixCompanys,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to get companys from database",
                    exceptionMessage: ex.Message
                );
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
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.GetParameters,
                    message: $"Error when trying to get parameters from database",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetParameters,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to get parameters from database",
                    exceptionMessage: ex.Message
                );
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
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.GetLast7DaysMinTimestamp,
                    message: $"Error when trying to get last timestamp from database",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetLast7DaysMinTimestamp,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to get last timestamp from database",
                    exceptionMessage: ex.Message
                );
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
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.InsertRecord,
                    message: $"Error when trying to insert record in database table: {jobParameter.tableName}",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.InsertRecord,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to insert record in database table: {jobParameter.tableName}",
                    exceptionMessage: ex.Message
                );
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
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.ExecuteQueryCommand,
                    message: $"Error when trying to execute command sql",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.ExecuteQueryCommand,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to execute command sql",
                    exceptionMessage: ex.Message
                );
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
                throw new InternalException(
                    stage: EnumStages.BulkInsertIntoTableRaw,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to bulk insert records on table raw",
                    exceptionMessage: ex.Message
                );
            }
        }

        public async Task<List<TEntity>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, string sql)
        {
            try
            {
                using (var conn = _sqlServerConnection.GetDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync<TEntity>(sql: sql, commandTimeout: 360);
                    return result.ToList();
                }
            }
            catch (SqlException ex)
            {
                throw new SQLCommandException(
                    stage: EnumStages.GetRegistersExists,
                    message: $"Error when trying to get records that already exist in trusted table",
                    exceptionMessage: ex.Message,
                    commandSQL: sql
                );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.SQLCommand,
                    level: EnumMessageLevel.Error,
                    message: $"Error when trying to get records that already exist in trusted table",
                    exceptionMessage: ex.Message
                );
            }
        }

        #region MOVER PARA PROJETO DATABASE INITIALIZATION
        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter, object parameter)
        {
            string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                         $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [timestamp], [dateinterval], [individual], [ativo]) " +
                          "VALUES (@method, @timestamp, @dateinterval, @individual, @ativo)";

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
                throw;
                //throw new ExecuteCommandException()
                //{
                //    project = $"{jobParameter.projectName} - IntegrationsCore",
                //    job = jobParameter.jobName,
                //    method = $"InsertRecord",
                //    message = $"Error when trying to insert record in database table: {jobParameter.tableName}",
                //    schema = $"[{jobParameter.tableName}]",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }
        #endregion
    }
}
