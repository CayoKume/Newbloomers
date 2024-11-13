using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCodebarRepository : IB2CConsultaProdutosCodebarRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCodebar> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCodebarRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCodebar> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosCodebar> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosCodebar());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigoproduto, records[i].codebar, records[i].id_produtos_codebar, records[i].principal, records[i].empresa, records[i].timestamp, records[i].tipo_codebar,
                        records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCODEBAR_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCODEBAR_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSCODEBAR_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSCODEBAR_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[CODEBAR] = SOURCE.[CODEBAR],
			                           TARGET.[ID_PRODUTOS_CODEBAR] = SOURCE.[ID_PRODUTOS_CODEBAR],
			                           TARGET.[PRINCIPAL] = SOURCE.[PRINCIPAL],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[TIPO_CODEBAR] = SOURCE.[TIPO_CODEBAR],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGOPRODUTO] NOT IN (SELECT [CODIGOPRODUTO] FROM [B2CCONSULTAPRODUTOSCODEBAR_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGOPRODUTO], [CODEBAR], [ID_PRODUTOS_CODEBAR], [PRINCIPAL], [EMPRESA], [TIMESTAMP], [TIPO_CODEBAR], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGOPRODUTO], SOURCE.[CODEBAR], SOURCE.[ID_PRODUTOS_CODEBAR], SOURCE.[PRINCIPAL], SOURCE.[EMPRESA], SOURCE.[TIMESTAMP], SOURCE.[TIPO_CODEBAR], SOURCE.[PORTAL]);
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
                                                  <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosCodebar? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [codigoproduto], [codebar], [id_produtos_codebar], [principal], [empresa], [timestamp], [tipo_codebar], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigoproduto, @codebar, @id_produtos_codebar, @principal, @empresa, @timestamp, @tipo_codebar, @portal)";

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
