using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosTabelasRepository : ILinxProdutosTabelasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosTabelas> _linxMicrovixRepositoryBase;

        public LinxProdutosTabelasRepository(ILinxMicrovixRepositoryBase<LinxProdutosTabelas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxProdutosTabelas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_tabela, records[i].portal, records[i].cnpj_emp, records[i].nome_tabela, records[i].ativa,
                        records[i].timestamp, records[i].tipo_tabela, records[i].codigo_integracao_ws);
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

        public async Task<List<LinxProdutosTabelas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosTabelas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_tabela}'";
                    else
                        identificadores += $"'{registros[i].id_tabela}', ";
                }

                string sql = $"SELECT id_tabela, TIMESTAMP FROM [linx_microvix_erp].[LinxProdutosTabelas] WHERE id_tabela IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[id_tabela],[portal],[cnpj_emp],[nome_tabela],[ativa],[timestamp],[tipo_tabela],[codigo_integracao_ws])
                            Values
                            (@lastupdateon,@id_tabela,@portal,@cnpj_emp,@nome_tabela,@ativa,@timestamp,@tipo_tabela,@codigo_integracao_ws)";

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
