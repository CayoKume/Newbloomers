using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosTabelasRepository : ILinxProdutosTabelasRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosTabelas> _linxMicrovixRepositoryBase;

        public LinxProdutosTabelasRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosTabelas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosTabelas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_tabela, records[i].portal, records[i].cnpj_emp, records[i].nome_tabela, records[i].ativa,
                        records[i].timestamp, records[i].tipo_tabela, records[i].codigo_integracao_ws);
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

        public async Task<List<string?>> GetRegistersExists()
        {
            try
            {
                string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', ID_TABELA, ']', '|', '[', TIPO_TABELA, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxProdutosTabelas]";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[id_tabela],[portal],[cnpj_emp],[nome_tabela],[ativa],[timestamp],[tipo_tabela],[codigo_integracao_ws])
                            Values
                            (@lastupdateon,@id_tabela,@portal,@cnpj_emp,@nome_tabela,@ativa,@timestamp,@tipo_tabela,@codigo_integracao_ws)";

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
