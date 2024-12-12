using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosRepository : IB2CConsultaProdutosAssociadosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosAssociados> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosAssociadosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosAssociados> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosAssociados> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosAssociados());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id, records[i].codigoproduto, records[i].codigoproduto_associado, records[i].coeficiente_desconto, records[i].timestamp, records[i].portal, records[i].qtde_item, records[i].item_obrigatorio);
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

        public async Task<bool> CreateTableMerge(LinxAPIParam jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSASSOCIADOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSASSOCIADOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSASSOCIADOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSASSOCIADOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID] = SOURCE.[ID]
		                           )
        
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID] = SOURCE.[ID],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[CODIGOPRODUTO_ASSOCIADO] = SOURCE.[CODIGOPRODUTO_ASSOCIADO],
			                           TARGET.[COEFICIENTE_DESCONTO] = SOURCE.[COEFICIENTE_DESCONTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[QTDE_ITEM] = SOURCE.[QTDE_ITEM],
			                           TARGET.[ITEM_OBRIGATORIO] = SOURCE.[ITEM_OBRIGATORIO]
        
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID] NOT IN (SELECT [ID] FROM [B2CCONSULTAPRODUTOSASSOCIADOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID], [CODIGOPRODUTO], [CODIGOPRODUTO_ASSOCIADO], [COEFICIENTE_DESCONTO], [TIMESTAMP], [PORTAL], [QTDE_ITEM], [ITEM_OBRIGATORIO])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID], SOURCE.[CODIGOPRODUTO], SOURCE.[CODIGOPRODUTO_ASSOCIADO], SOURCE.[COEFICIENTE_DESCONTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[QTDE_ITEM], SOURCE.[ITEM_OBRIGATORIO]);
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

        public async Task<List<B2CConsultaProdutosAssociados>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosAssociados> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id}'";
                    else
                        identificadores += $"'{registros[i].id}', ";
                }

                string sql = $"SELECT ID, TIMESTAMP FROM B2CCONSULTAPRODUTOSASSOCIADOS_TRUSTED WHERE ID IN ({identificadores})";

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

        public async Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosAssociados? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id], [codigoproduto], [codigoproduto_associado], [coeficiente_desconto], [timestamp], [portal], [qtde_item], [item_obrigatorio]) " +
                          "Values " +
                          "(@lastupdateon, @id, @codigoproduto, @codigoproduto_associado, @coeficiente_desconto, @timestamp, @portal, @qtde_item, @item_obrigatorio)";

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
