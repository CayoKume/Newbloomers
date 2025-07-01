using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Infrastructure.IntegrationsCore.Connections.MySQL;
using Infrastructure.IntegrationsCore.Connections.PostgreSQL;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.Base
{
    public class LinxMicrovixRepositoryBase<TEntity> : ILinxMicrovixRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly string? _parametersTableName;

        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly IConfiguration _configuration;
        
        private readonly ISQLServerConnection? _sqlServerConnection;
        private readonly IMySQLConnection? _mySQLConnection;
        private readonly IPostgreSQLConnection? _postgreSQLConnection;

        public LinxMicrovixRepositoryBase(
            IIntegrationsCoreRepository integrationsCoreRepository,
            ISQLServerConnection sqlServerConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _integrationsCoreRepository = integrationsCoreRepository;
            _sqlServerConnection = sqlServerConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxMicrovix")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public LinxMicrovixRepositoryBase(
            IIntegrationsCoreRepository integrationsCoreRepository,
            IMySQLConnection mySQLConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _integrationsCoreRepository = integrationsCoreRepository;
            _mySQLConnection = mySQLConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxMicrovix")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public LinxMicrovixRepositoryBase(
            IIntegrationsCoreRepository integrationsCoreRepository,
            IPostgreSQLConnection postgreSQLConnection,
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _integrationsCoreRepository = integrationsCoreRepository;
            _postgreSQLConnection = postgreSQLConnection;
            _parametersTableName = _configuration
                                    .GetSection("LinxMicrovix")
                                    .GetSection("ProjectParametersTableName")
                                    .Value;
        }

        public async Task<string?> GetParameters(string? parametersInterval, string? parametersTableName, string? jobName)
        {
            string? sql = $"SELECT {parametersInterval} " +
                          $"FROM [LINX_MICROVIX].[{parametersTableName}] (NOLOCK) " +
                           "WHERE " +
                          $"METHOD = '{jobName}'";

            try
            {
                return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string?>> GetParameters(string sql)
        {
            try
            {
                return await _integrationsCoreRepository.GetRecords<string>(sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Company?>> GetB2CCompanys()
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
                           [LINX_MICROVIX_COMMERCE].[B2CCONSULTAEMPRESAS] (NOLOCK)";

            try
            {
                return await _integrationsCoreRepository.GetRecords<Company>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryAsync<Company>(sql: sql);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetParameters,
            //        message: $"Error when trying to get companys from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetB2CCompanys,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get companys from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<IEnumerable<Company?>> GetMicrovixCompanys()
        {
            string? sql = @"SELECT  
                           EMPRESA AS COD_COMPANY,
                           CNPJ_EMP AS DOC_COMPANY,
                           RAZAO_EMP AS REASON_COMPANY,
                           NOME_EMP AS NAME_COMPANY,
                           INSCRICAO_EMP AS STATE_REGISTRATION_COMPANY,
                           EMAIL_EMP AS EMAIL_COMPANY,
                           ENDERECO_EMP AS ADDRESS_COMPANY,
                           NUM_EMP AS STREET_NUMBER_COMPANY,
                           COMPLEMENT_EMP AS COMPLEMENT_ADDRESS_COMPANY,
                           BAIRRO_EMP AS NEIGHBORHOOD_COMPANY,
                           CIDADE_EMP AS CITY_COMPANY,
                           ESTADO_EMP AS UF_COMPANY,
                           CEP_EMP AS ZIP_CODE_COMPANY,
                           FONE_EMP AS FONE_COMPANY,
                           INSCRICAO_MUNICIPAL_EMP AS MUNICIPAL_REGISTRATION_COMPANY
                           FROM 
                           [LINX_MICROVIX_ERP].[LINXLOJAS] (NOLOCK)";

            try
            {
                return await _integrationsCoreRepository.GetRecords<Company>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryAsync<Company>(sql: sql);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetMicrovixCompanys,
            //        message: $"Error when trying to get companys from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetMicrovixCompanys,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get companys from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<IEnumerable<Company?>> GetMicrovixGroupCompanys()
        {
            string? sql = @"SELECT  
                           EMPRESA AS COD_COMPANY,
                           CNPJ AS DOC_COMPANY,
                           NOME_EMPRESA AS REASON_COMPANY,
                           NOME_EMPRESA AS NAME_COMPANY
                           FROM 
                           [LINX_MICROVIX_ERP].[LINXGRUPOLOJAS] (NOLOCK)
                           WHERE CNPJ <> ''";

            try
            {
                return await _integrationsCoreRepository.GetRecords<Company>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryAsync<Company>(sql: sql);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetMicrovixCompanys,
            //        message: $"Error when trying to get companys from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetMicrovixGroupCompanys,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get companys from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID)
        {
            try
            {
                return await _integrationsCoreRepository.CallDbProcMerge(schemaName, tableName, parentExecutionGUID);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(string tableName, string? sql, object record)
        {
            try
            {
                return await _integrationsCoreRepository.InsertRecord(sql, record);
            }
            catch
            {
                throw;
            }
        }

        public DataTable CreateSystemDataTable(string? tableName, TEntity entity)
        {
            try
            {
                return _integrationsCoreRepository.CreateSystemDataTable(tableName, entity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string?> GetLast7DaysMaxTimestamp(string? schema, string? tableName)
        {
            string? sql = "SELECT ISNULL(MAX(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK)";

            try
            {
                return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<string?> GetLastMaxTimestamp(string? schema, string? tableName, string? columnCompany, string? companyValue)
        {
            string? sql = "SELECT ISNULL(MAX(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK)" +
                         $"WHERE [{columnCompany}] = '{companyValue}'";

            try
            {
                return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<string?> GetLastMaxTimestampByCnpjAndIdentificador(string? schema, string? tableName, string? columnCompany, string? companyValue, string? columnIdentificador, string? columnIdentificadorValue)
        {
            string? sql = "SELECT ISNULL(MAX(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK)" +
                         $"WHERE [{columnCompany}] = '{companyValue}'" +
                         $"AND [{columnIdentificador}] = '{columnIdentificadorValue}'";

            try
            {
                return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate)
        {
            string? sql = "SELECT ISNULL(MIN(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK) " +
                          "WHERE " +
                         $"{columnDate} > GETDATE() - 7";

            try
            {
                return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate, string? columnCompany, string? companyValue)
        {
            string? sql = "SELECT ISNULL(MIN(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK) " +
                          "WHERE " +
                         $"{columnDate} > GETDATE() - 7 AND {columnCompany} = '{companyValue}'";

            try
            {
                return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetIDbConnection())
            //    {
            //        return await conn.QueryFirstOrDefaultAsync<string?>(sql: sql, commandTimeout: 360);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetLast7DaysMinTimestamp,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get last timestamp from database",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }

        public async Task<bool> ExecuteQueryCommand(string? sql)
        {
            try
            {
                return await _integrationsCoreRepository.ExecuteCommand(sql);
            }
            catch
            {
                throw;
            }
        }

        public bool BulkInsertIntoTableRaw(DataTable dataTable)
        {
            try
            {
                _integrationsCoreRepository.BulkInsertIntoTableRaw(dataTable);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity?>> GetRegistersExists(string sql)
        {
            try
            {
                return await _integrationsCoreRepository.GetRecords<TEntity>(sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string?>> GetKeyRegistersAlreadyExists(string sql)
        {
            try
            {
                return await _integrationsCoreRepository.GetRecords<string>(sql: sql);
            }
            catch
            {
                throw;
            }

            //try
            //{
            //    using (var conn = _sqlServerConnection.GetDbConnection())
            //    {
            //        var result = await conn.QueryAsync<string>(sql: sql, commandTimeout: 360);
            //        return result.ToList();
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw new SQLCommandException(
            //        stage: EnumStages.GetRegistersExists,
            //        message: $"Error when trying to get records that already exist in trusted table",
            //        exceptionMessage: ex.Message,
            //        commandSQL: sql
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new InternalException(
            //        stage: EnumStages.GetRegistersExists,
            //        error: EnumError.SQLCommand,
            //        level: EnumMessageLevel.Error,
            //        message: $"Error when trying to get records that already exist in trusted table",
            //        exceptionMessage: ex.Message
            //    );
            //}
        }
    }
}
