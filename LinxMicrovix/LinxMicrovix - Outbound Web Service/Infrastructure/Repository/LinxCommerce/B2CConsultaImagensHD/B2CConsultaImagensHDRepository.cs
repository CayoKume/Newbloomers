using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaImagensHDRepository :IB2CConsultaImagensHDRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaImagensHD> _linxMicrovixRepositoryBase;

        public B2CConsultaImagensHDRepository(ILinxMicrovixRepositoryBase<B2CConsultaImagensHD> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaImagensHD> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaImagensHD());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].identificador_imagem, records[i].codigoproduto, records[i].imagem, records[i].timestamp, records[i].url_imagem_blob, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAIMAGENSHD_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAIMAGENSHD_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAIMAGENSHD_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAIMAGENSHD_RAW] AS SOURCE

                                   ON (
			                           TARGET.[IDENTIFICADOR_IMAGEM] = SOURCE.[IDENTIFICADOR_IMAGEM]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[IDENTIFICADOR_IMAGEM] = SOURCE.[IDENTIFICADOR_IMAGEM],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[IMAGEM] = SOURCE.[IMAGEM],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[URL_IMAGEM_BLOB] = SOURCE.[URL_IMAGEM_BLOB],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[IDENTIFICADOR_IMAGEM] NOT IN (SELECT [IDENTIFICADOR_IMAGEM] FROM [B2CCONSULTAIMAGENSHD_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [IDENTIFICADOR_IMAGEM], [CODIGOPRODUTO], [IMAGEM], [TIPO_PESSOA], [TIMESTAMP], [URL_IMAGEM_BLOB], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[IDENTIFICADOR_IMAGEM], SOURCE.[CODIGOPRODUTO], SOURCE.[IMAGEM], SOURCE.[TIPO_PESSOA], SOURCE.[TIMESTAMP], SOURCE.[URL_IMAGEM_BLOB], SOURCE.[PORTAL]);"";
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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaImagensHD? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [portal], [identificador_imagem], [codigoproduto], [imagem], [timestamp], [url_imagem_blob]) " +
                          "Values " +
                          "(@lastupdateon, @portal, @identificador_imagem, @codigoproduto, @imagem, @timestamp, @url_imagem_blob)";

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
