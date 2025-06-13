using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosCamposAdicionaisRepository : ILinxProdutosCamposAdicionaisRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosCamposAdicionais> _linxMicrovixRepositoryBase;

        public LinxProdutosCamposAdicionaisRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosCamposAdicionais> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosCamposAdicionais> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosCamposAdicionais());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cod_produto, records[i].campo, records[i].valor, records[i].timestamp);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
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

        public async Task<List<string>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosCamposAdicionais> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].cod_produto}'";
                    else
                        identificadores += $"'{registros[i].cod_produto}', ";
                }

                string sql = $"SELECT CONCAT('[', COD_PRODUTO, ']', '|', '[', CAMPO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxProdutosCamposAdicionais] WHERE COD_PRODUTO IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCamposAdicionais? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[cod_produto],[campo],[valor],[timestamp])
                            Values
                            (@lastupdateon,@portal,@cod_produto,@campo,@valor,@timestamp)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
