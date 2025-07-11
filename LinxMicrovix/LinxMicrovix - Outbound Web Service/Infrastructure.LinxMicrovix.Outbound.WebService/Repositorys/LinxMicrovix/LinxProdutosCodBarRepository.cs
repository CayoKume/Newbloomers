using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosCodBarRepository : ILinxProdutosCodBarRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosCodBar> _linxMicrovixRepositoryBase;

        public LinxProdutosCodBarRepository(ILinxMicrovixRepositoryBase<LinxProdutosCodBar> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosCodBar> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosCodBar());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].cod_produto, records[i].cod_barra, records[i].portal, records[i].timestamp);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetProductsSetorIds(LinxAPIParam jobParameter)
        {
            string sql = $"SELECT distinct id_setor FROM [linx_microvix_erp].[LinxSetores]";

            return await _linxMicrovixRepositoryBase.GetParameters(sql);
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i]}'";
                else
                    identificadores += $"'{registros[i]}', ";
            }

            string sql = $"SELECT CONCAT('[', COD_PRODUTO, ']', '|', '[', COD_BARRA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxProdutosCodBar] WHERE cod_produto IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCodBar? record)
        {
            string? sql = $"INSERT INTO [untreated].[{jobParameter.tableName}] " +
                          "([lastupdateon], [portal], [cod_produto], [cod_barra], [timestamp]) " +
                          "Values " +
                          "(@lastupdateon, @portal, @cod_produto, @cod_barra, @timestamp)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
