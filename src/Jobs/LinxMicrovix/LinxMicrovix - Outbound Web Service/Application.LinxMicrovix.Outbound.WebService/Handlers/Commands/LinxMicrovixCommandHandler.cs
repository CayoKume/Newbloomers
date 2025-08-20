using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class LinxMicrovixCommandHandler : ILinxMicrovixCommandHandler
    {
        public string CreateGetParametersQuery(string parametersInterval, string parametersTableName, string jobName)
        {
            return $"SELECT {parametersInterval} FROM [LINX_MICROVIX].[{parametersTableName}] (NOLOCK) WHERE METHOD = '{jobName}'";
        }

        public string CreateGetB2CCompanysQuery()
        {
            return @"SELECT  
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
                       CEP_UNidade AS ZIP_CODE_COMPANY,
                       '' AS FONE_COMPANY,
                       '' AS STATE_REGISTRATION_COMPANY,
                       '' AS MUNICIPAL_REGISTRATION_COMPANY
                       FROM 
                       [LINX_MICROVIX_COMMERCE].[B2CCONSULTAEMPRESAS] (NOLOCK)";
        }

        public string CreateGetMicrovixCompanysQuery()
        {
            return @"SELECT  
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
        }

        public string CreateGetMicrovixGroupCompanysQuery()
        {
            return @"SELECT  
                       EMPRESA AS COD_COMPANY,
                       CNPJ AS DOC_COMPANY,
                       NOME_EMPRESA AS REASON_COMPANY,
                       NOME_EMPRESA AS NAME_COMPANY
                       FROM 
                       [LINX_MICROVIX_ERP].[LINXGRUPOLOJAS] (NOLOCK)
                       WHERE CNPJ <> ''";
        }

        public string CreateGetLast7DaysMaxTimestampQuery(string schema, string tableName)
        {
            return $"SELECT ISNULL(MAX(TIMESTAMP), 0) FROM [{schema}].[{tableName}] (NOLOCK)";
        }

        public string CreateGetLastMaxTimestampQuery(string schema, string tableName, string columnCompany, string companyValue)
        {
            return $"SELECT ISNULL(MAX(TIMESTAMP), 0) FROM [{schema}].[{tableName}] (NOLOCK) WHERE [{columnCompany}] = '{companyValue}'";
        }

        public string CreateGetLastMaxTimestampByCnpjAndIdentificadorQuery(string schema, string tableName, string columnCompany, string companyValue, string columnIdentificador, string columnIdentificadorValue)
        {
            return $"SELECT ISNULL(MAX(TIMESTAMP), 0) FROM [{schema}].[{tableName}] (NOLOCK) WHERE [{columnCompany}] = '{companyValue}' AND [{columnIdentificador}] = '{columnIdentificadorValue}'";
        }

        public string CreateGetLast7DaysMinTimestampQuery(string schema, string tableName, string columnDate)
        {
            return $"SELECT ISNULL(MIN(TIMESTAMP), 0) FROM [{schema}].[{tableName}] (NOLOCK) WHERE {columnDate} > GETDATE() - 7";
        }

        public string CreateGetLast7DaysMinTimestampWithCompanyQuery(string schema, string tableName, string columnDate, string columnCompany, string companyValue)
        {
            return $"SELECT ISNULL(MIN(TIMESTAMP), 0) FROM [{schema}].[{tableName}] (NOLOCK) WHERE {columnDate} > GETDATE() - 7 AND {columnCompany} = '{companyValue}'";
        }
    }
}
