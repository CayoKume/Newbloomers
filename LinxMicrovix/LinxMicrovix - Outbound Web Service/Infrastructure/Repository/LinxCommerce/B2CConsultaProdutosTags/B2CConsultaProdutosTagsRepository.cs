using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosTagsRepository<TEntity> : IB2CConsultaProdutosTagsRepository<TEntity> where TEntity : B2CConsultaProdutosTags, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosTagsRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].id_b2c_tags_produtos, records[i].id_b2c_tags, records[i].codigoproduto, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSTAGS_SYNC')
                            BEGIN
                            EXECUTE (
	                            'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSTAGS_SYNC] AS
	                            BEGIN
		                            MERGE [B2CCONSULTAPRODUTOSTAGS_TRUSTED] AS TARGET
                                    USING [B2CCONSULTAPRODUTOSTAGS_RAW] AS SOURCE

                                    ON (
			                            TARGET.[ID_B2C_TAGS_PRODUTOS] = SOURCE.[ID_B2C_TAGS_PRODUTOS]
		                            )

                                    WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                            UPDATE SET
			                            TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                            TARGET.[ID_B2C_TAGS_PRODUTOS] = SOURCE.[ID_B2C_TAGS_PRODUTOS],
			                            TARGET.[ID_B2C_TAGS] = SOURCE.[ID_B2C_TAGS],
			                            TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                            TARGET.[DESCRICAO_B2C_TAGS] = SOURCE.[DESCRICAO_B2C_TAGS],
			                            TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                            TARGET.[PORTAL] = SOURCE.[PORTAL]

                                    WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_TAGS_PRODUTOS] NOT IN (SELECT [ID_B2C_TAGS_PRODUTOS] FROM [B2CCONSULTAPRODUTOSTAGS_TRUSTED]) THEN
			                            INSERT
			                            ([LASTUPDATEON], [ID_B2C_TAGS_PRODUTOS], [ID_B2C_TAGS], [CODIGOPRODUTO], [DESCRICAO_B2C_TAGS], [TIMESTAMP], [PORTAL])
			                            VALUES
			                            (SOURCE.[LASTUPDATEON], SOURCE.[ID_B2C_TAGS_PRODUTOS], SOURCE.[ID_B2C_TAGS], SOURCE.[CODIGOPRODUTO], SOURCE.[DESCRICAO_B2C_TAGS], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
