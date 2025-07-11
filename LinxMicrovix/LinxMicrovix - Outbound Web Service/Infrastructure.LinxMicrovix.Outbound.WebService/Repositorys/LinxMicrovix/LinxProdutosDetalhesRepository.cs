using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosDetalhesRepository : ILinxProdutosDetalhesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosDetalhes> _linxMicrovixRepositoryBase;

        public LinxProdutosDetalhesRepository(ILinxMicrovixRepositoryBase<LinxProdutosDetalhes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosDetalhes> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosDetalhes());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_produto, records[i].cod_barra, records[i].quantidade,
                    records[i].preco_custo, records[i].preco_venda, records[i].custo_medio, records[i].id_config_tributaria, records[i].desc_config_tributaria, records[i].despesas1,
                    records[i].qtde_minima, records[i].qtde_maxima, records[i].ipi, records[i].timestamp, records[i].empresa);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<LinxProdutosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosDetalhes> registros)
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

        public async Task<IEnumerable<LinxProdutosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter)
        {
            string sql = $"SELECT DISTINCT top 30000 cod_produto, cnpj_emp FROM [linx_microvix_erp].[LinxProdutosDetalhes] where desc_config_tributaria = 'pendente'";

            return await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosDetalhes? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[cnpj_emp],[cod_produto],[cod_barra],[quantidade],[preco_custo],[preco_venda],[custo_medio],[id_config_tributaria],[desc_config_tributaria],
                             [despesas1],[qtde_minima],[qtde_maxima],[ipi],[timestamp],[empresa])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@cod_produto,@cod_barra,@quantidade,@preco_custo,@preco_venda,@custo_medio,@id_config_tributaria,@desc_config_tributaria,
                             @despesas1,@qtde_minima,@qtde_maxima,@ipi,@timestamp,@empresa)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
