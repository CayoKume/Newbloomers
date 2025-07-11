using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosInventarioRepository : ILinxProdutosInventarioRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosInventario> _linxMicrovixRepositoryBase;

        public LinxProdutosInventarioRepository(ILinxMicrovixRepositoryBase<LinxProdutosInventario> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosInventario> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosInventario());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_produto, records[i].cod_barra, records[i].quantidade,
                    records[i].cod_deposito, records[i].empresa);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetProductsDepositsIds(LinxAPIParam jobParameter)
        {
            string sql = $"SELECT distinct cod_deposito FROM [linx_microvix_erp].[LinxProdutosDepositos]";

            return await _linxMicrovixRepositoryBase.GetParameters(sql);
        }

        public async Task<IEnumerable<LinxProdutosInventario>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosInventario> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].cod_produto}'";
                else
                    identificadores += $"'{registros[i].cod_produto}', ";
            }

            string sql = $"SELECT cnpj_emp, cod_produto, cod_deposito, quantidade FROM [linx_microvix_erp].[LinxProdutosInventario] WHERE cod_produto IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosInventario? record)
        {
            string? sql = @$"INSERT INTO {jobParameter.tableName} 
                            ([lastupdateon],[portal],[cnpj_emp],[cod_produto],[cod_barra],[quantidade],[cod_deposito],[empresa])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@cod_produto,@cod_barra,@quantidade,@cod_deposito,@empresa)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
