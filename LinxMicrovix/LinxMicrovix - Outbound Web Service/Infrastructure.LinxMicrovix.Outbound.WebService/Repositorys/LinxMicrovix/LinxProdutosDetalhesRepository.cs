using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosDetalhesRepository : ILinxProdutosDetalhesRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosDetalhes> _linxMicrovixRepositoryBase;

        public LinxProdutosDetalhesRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosDetalhes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDetalhes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosDetalhes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_produto, records[i].cod_barra, records[i].quantidade,
                        records[i].preco_custo, records[i].preco_venda, records[i].custo_medio, records[i].id_config_tributaria, records[i].desc_config_tributaria, records[i].despesas1,
                        records[i].qtde_minima, records[i].qtde_maxima, records[i].ipi, records[i].timestamp, records[i].empresa);
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

        public async Task<List<LinxProdutosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhes> registros)
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

                string sql = $"SELECT cnpj_emp, cod_produto, TIMESTAMP FROM [linx_microvix_erp].[LinxProdutosDetalhes] WHERE cod_produto IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhes? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[cnpj_emp],[cod_produto],[cod_barra],[quantidade],[preco_custo],[preco_venda],[custo_medio],[id_config_tributaria],[desc_config_tributaria],
                             [despesas1],[qtde_minima],[qtde_maxima],[ipi],[timestamp],[empresa])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@cod_produto,@cod_barra,@quantidade,@preco_custo,@preco_venda,@custo_medio,@id_config_tributaria,@desc_config_tributaria,
                             @despesas1,@qtde_minima,@qtde_maxima,@ipi,@timestamp,@empresa)";

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
