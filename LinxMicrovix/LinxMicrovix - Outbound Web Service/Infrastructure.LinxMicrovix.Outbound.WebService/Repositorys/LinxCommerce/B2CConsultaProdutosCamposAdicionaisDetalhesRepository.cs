using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhesRepository : IB2CConsultaProdutosCamposAdicionaisDetalhesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisDetalhes> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCamposAdicionaisDetalhesRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisDetalhes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosCamposAdicionaisDetalhes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosCamposAdicionaisDetalhes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_campo_detalhe, records[i].ordem, records[i].descricao, records[i].id_campo, records[i].ativo, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_CAMPO_DETALHE] = SOURCE.[ID_CAMPO_DETALHE]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_CAMPO_DETALHE] = SOURCE.[ID_CAMPO_DETALHE],
			                           TARGET.[ORDEM] = SOURCE.[ORDEM],
			                           TARGET.[DESCRICAO] = SOURCE.[DESCRICAO],
			                           TARGET.[ID_CAMPO] = SOURCE.[ID_CAMPO],
			                           TARGET.[ATIVO] = SOURCE.[ATIVO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_CAMPO_DETALHE] NOT IN (SELECT [ID_CAMPO_DETALHE] FROM [B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_CAMPO_DETALHE], [ORDEM], [DESCRICAO], [ID_CAMPO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_CAMPO_DETALHE], SOURCE.[ORDEM], SOURCE.[DESCRICAO], SOURCE.[ID_CAMPO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosCamposAdicionaisDetalhes>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosCamposAdicionaisDetalhes> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_campo_detalhe}'";
                    else
                        identificadores += $"'{registros[i].id_campo_detalhe}', ";
                }

                string sql = $"SELECT ID_CAMPO_DETALHE, TIMESTAMP FROM B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES_TRUSTED WHERE ID_CAMPO_DETALHE IN ({identificadores})";

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
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""id_campo"">[id_campo]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosCamposAdicionaisDetalhes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_campo_detalhe], [ordem], [descricao], [id_campo], [ativo], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_campo_detalhe, @ordem, @descricao, @id_campo, @ativo, @timestamp, @portal)";

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
