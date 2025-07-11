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

            return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
        }

        public async Task<IEnumerable<string?>> GetParameters(string sql)
        {
            return await _integrationsCoreRepository.GetRecords<string>(sql: sql);
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

            return await _integrationsCoreRepository.GetRecords<Company>(sql: sql);
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

            return await _integrationsCoreRepository.GetRecords<Company>(sql: sql);
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

            return await _integrationsCoreRepository.GetRecords<Company>(sql: sql);
        }

        public async Task<bool> CallDbProcMerge(string schemaName, string tableName, Guid? parentExecutionGUID)
        {
            return await _integrationsCoreRepository.CallDbProcMerge(schemaName, tableName, parentExecutionGUID);
        }

        public async Task<bool> InsertRecord(string tableName, string? sql, object record)
        {
            return await _integrationsCoreRepository.InsertRecord(sql, record);
        }

        public DataTable CreateSystemDataTable(string? tableName, TEntity entity)
        {
            return _integrationsCoreRepository.CreateSystemDataTable(tableName, entity);
        }

        public async Task<string?> GetLast7DaysMaxTimestamp(string? schema, string? tableName)
        {
            string? sql = "SELECT ISNULL(MAX(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK)";

            return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
        }

        public async Task<string?> GetLastMaxTimestamp(string? schema, string? tableName, string? columnCompany, string? companyValue)
        {
            string? sql = "SELECT ISNULL(MAX(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK)" +
                         $"WHERE [{columnCompany}] = '{companyValue}'";

            return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
        }

        public async Task<string?> GetLastMaxTimestampByCnpjAndIdentificador(string? schema, string? tableName, string? columnCompany, string? companyValue, string? columnIdentificador, string? columnIdentificadorValue)
        {
            string? sql = "SELECT ISNULL(MAX(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK)" +
                         $"WHERE [{columnCompany}] = '{companyValue}'" +
                         $"AND [{columnIdentificador}] = '{columnIdentificadorValue}'";

            return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
        }

        public async Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate)
        {
            string? sql = "SELECT ISNULL(MIN(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK) " +
                          "WHERE " +
                         $"{columnDate} > GETDATE() - 7";

            return await _integrationsCoreRepository.GetRecord<string>(sql: sql);
        }

        public async Task<string?> GetLast7DaysMinTimestamp(string? schema, string? tableName, string? columnDate, string? columnCompany, string? companyValue)
        {
            string? sql = "SELECT ISNULL(MIN(TIMESTAMP), 0) " +
                         $"FROM [{schema}].[{tableName}] (NOLOCK) " +
                          "WHERE " +
                         $"{columnDate} > GETDATE() - 7 AND {columnCompany} = '{companyValue}'";

            return await _integrationsCoreRepository.GetRecord<string>(sql: sql); 
        }

        public async Task<bool> ExecuteQueryCommand(string? sql)
        {
            return await _integrationsCoreRepository.ExecuteCommand(sql);
        }

        public bool BulkInsertIntoTableRaw(DataTable dataTable)
        {
            return _integrationsCoreRepository.BulkInsertIntoTableRaw(dataTable);
        }

        public async Task<IEnumerable<TEntity?>> GetRegistersExists(string sql)
        {
            return await _integrationsCoreRepository.GetRecords<TEntity>(sql: sql);
        }

        public async Task<IEnumerable<string?>> GetKeyRegistersAlreadyExists(string sql)
        {
            return await _integrationsCoreRepository.GetRecords<string>(sql: sql);
        }
    }
}
