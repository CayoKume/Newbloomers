using Domain.IntegrationsCore.Entities.Parameters;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaPlanosRepository : IB2CConsultaPlanosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPlanos> _linxMicrovixRepositoryBase;

        public B2CConsultaPlanosRepository(ILinxMicrovixRepositoryBase<B2CConsultaPlanos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaPlanos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPlanos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].plano, records[i].nome_plano, records[i].forma_pagamento, records[i].qtde_parcelas, records[i].valor_minimo_parcela, records[i].indice, records[i].timestamp,
                        records[i].desativado, records[i].tipo_plano, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPLANOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPLANOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPLANOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPLANOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[PLANO] = SOURCE.[PLANO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[PLANO] = SOURCE.[PLANO],
			                           TARGET.[NOME_PLANO] = SOURCE.[NOME_PLANO],
			                           TARGET.[FORMA_PAGAMENTO] = SOURCE.[FORMA_PAGAMENTO],
			                           TARGET.[QTDO_PARCELA] = SOURCE.[QTDO_PARCELA],
			                           TARGET.[VALOR_MINIMO_PARCELA] = SOURCE.[VALOR_MINIMO_PARCELA],
			                           TARGET.[INDICE] = SOURCE.[INDICE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[DESATIVADO] = SOURCE.[DESATIVADO],
			                           TARGET.[TIPO_PLANO] = SOURCE.[TIPO_PLANO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[PLANO] NOT IN (SELECT [PLANO] FROM [B2CCONSULTAPLANOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [PLANO], [NOME_PLANO], [FORMA_PAGAMENTO], [QTDO_PARCELA], [VALOR_MINIMO_PARCELA], [INDICE], [TIMESTAMP], [DESATIVADO], [TIPO_PLANO], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[PLANO], SOURCE.[NOME_PLANO], SOURCE.[FORMA_PAGAMENTO], SOURCE.[QTDO_PARCELA], SOURCE.[VALOR_MINIMO_PARCELA], SOURCE.[INDICE], SOURCE.[TIMESTAMP], SOURCE.[DESATIVADO], SOURCE.[TIPO_PLANO], SOURCE.[PORTAL]);
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

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""plano"">[plano]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaPlanos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [plano], [nome_plano], [forma_pagamento], [qtde_parcelas], [valor_minimo_parcela], [indice], [timestamp], [desativado], [tipo_plano], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @plano, @nome_plano, @forma_pagamento, @qtde_parcelas, @valor_minimo_parcela, @indice, @timestamp, @desativado, @tipo_plano, @portal)";

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
