using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaCNPJsChaveRepository : IB2CConsultaCNPJsChaveRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaCNPJsChave> _linxMicrovixRepositoryBase;

        public B2CConsultaCNPJsChaveRepository(ILinxMicrovixRepositoryBase<B2CConsultaCNPJsChave> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaCNPJsChave> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaCNPJsChave());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cnpj, records[i].nome_empresa, records[i].id_empresas_rede, records[i].rede, records[i].portal, records[i].nome_portal, 
                        records[i].empresa, records[i].classificacao_portal, records[i].b2c, records[i].oms);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACNPJSCHAVE_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACNPJSCHAVE_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACNPJSCHAVE_TRUSTED] AS TARGET
                                   USING [B2CCONSULTACNPJSCHAVE_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CNPJ] = SOURCE.[CNPJ]
		                           )

                                   WHEN MATCHED AND (TARGET.[B2C] != SOURCE.[B2C] OR TARGET.[OMS] != SOURCE.[OMS]) THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CNPJ] = SOURCE.[CNPJ],
			                           TARGET.[NOME_EMPRESA] = SOURCE.[NOME_EMPRESA],
			                           TARGET.[ID_EMPRESAS_REDE] = SOURCE.[ID_EMPRESAS_REDE],
			                           TARGET.[REDE] = SOURCE.[REDE],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[NOME_PORTAL] = SOURCE.[NOME_PORTAL],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[CLASSIFICACAO_PORTAL] = SOURCE.[CLASSIFICACAO_PORTAL],
			                           TARGET.[B2C] = SOURCE.[B2C],
			                           TARGET.[OMS] = SOURCE.[OMS]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CNPJ] NOT IN (SELECT [CNPJ] FROM [B2CCONSULTACNPJSCHAVE_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CNPJ], [NOME_EMPRESA], [ID_EMPRESAS_REDE], [REDE], [PORTAL], [NOME_PORTAL], [EMPRESA], [CLASSIFICACAO_PORTAL], [B2C], [OMS])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CNPJ], SOURCE.[NOME_EMPRESA], SOURCE.[ID_EMPRESAS_REDE], SOURCE.[REDE], SOURCE.[PORTAL], SOURCE.[NOME_PORTAL], 
			                           SOURCE.[EMPRESA], SOURCE.[CLASSIFICACAO_PORTAL], SOURCE.[B2C], SOURCE.[OMS]);
	                           END'
                           )
                           END";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<B2CConsultaCNPJsChave>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaCNPJsChave> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_empresas_rede}'";
                    else
                        identificadores += $"'{registros[i].id_empresas_rede}', ";
                }

                string sql = $"SELECT ID_EMPRESAS_REDE, TIMESTAMP FROM B2CCONSULTACNPJSCHAVE_TRUSTED WHERE ID_EMPRESAS_REDE IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"",
                        parameters_dateinterval = @"",
                        parameters_individual = @"<Parameter id=""cod_cliente_erp"">[cod_cliente_erp]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaCNPJsChave? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [cnpj], [nome_empresa], [id_empresas_rede], [rede], [portal], [nome_portal], [empresa], [classificacao_portal], [b2c], [oms]) " +
                          "Values " +
                          "(@lastupdateon, @cnpj, @nome_empresa, @id_empresas_rede, @rede, @portal, @nome_portal, @empresa, @classificacao_portal, @b2c, @oms)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
