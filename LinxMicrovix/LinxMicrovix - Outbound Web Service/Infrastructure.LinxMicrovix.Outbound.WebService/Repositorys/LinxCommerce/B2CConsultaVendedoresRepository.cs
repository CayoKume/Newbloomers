using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaVendedoresRepository : IB2CConsultaVendedoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaVendedores> _linxMicrovixRepositoryBase;

        public B2CConsultaVendedoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaVendedores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaVendedores> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaVendedores());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].cod_vendedor, records[i].nome_vendedor, records[i].comissao_produtos, records[i].comissao_servicos, records[i].tipo, records[i].ativo, records[i].comissionado, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaVendedores> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].cod_vendedor}'";
                else
                    identificadores += $"'{registros[i].cod_vendedor}', ";
            }

            string sql = $"SELECT CONCAT('[', COD_VENDEDOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAVENDEDORES] WHERE COD_VENDEDOR IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaVendedores? record)
        {
            string? sql = $"INSERT INTO [untreated].[{jobParameter.tableName}]" +
                          "([lastupdateon], [cod_vendedor], [nome_vendedor], [comissao_produtos], [comissao_servicos], [tipo], [ativo], [comissionado], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_vendedor, @nome_vendedor, @comissao_produtos, @comissao_servicos, @tipo, @ativo, @comissionado, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
