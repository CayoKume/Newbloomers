using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosTabelasRepository : ILinxProdutosTabelasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosTabelas> _linxMicrovixRepositoryBase;

        public LinxProdutosTabelasRepository(ILinxMicrovixRepositoryBase<LinxProdutosTabelas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelas> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosTabelas());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_tabela, records[i].portal, records[i].cnpj_emp, records[i].nome_tabela, records[i].ativa,
                    records[i].timestamp, records[i].tipo_tabela, records[i].codigo_integracao_ws);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists()
        {
            string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', ID_TABELA, ']', '|', '[', TIPO_TABELA, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxProdutosTabelas]";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[id_tabela],[portal],[cnpj_emp],[nome_tabela],[ativa],[timestamp],[tipo_tabela],[codigo_integracao_ws])
                            Values
                            (@lastupdateon,@id_tabela,@portal,@cnpj_emp,@nome_tabela,@ativa,@timestamp,@tipo_tabela,@codigo_integracao_ws)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
