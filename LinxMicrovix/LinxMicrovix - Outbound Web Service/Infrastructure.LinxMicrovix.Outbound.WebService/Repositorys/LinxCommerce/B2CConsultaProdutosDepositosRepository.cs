using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosDepositosRepository : IB2CConsultaProdutosDepositosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosDepositos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosDepositosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosDepositos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosDepositos> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosDepositos());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_deposito, records[i].nome_deposito, records[i].disponivel, records[i].disponivel_transferencia, records[i].disponivel_franquias, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosDepositos> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_deposito}'";
                else
                    identificadores += $"'{registros[i].id_deposito}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_DEPOSITO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSDEPOSITOS] WHERE ID_DEPOSITO IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosDepositos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_deposito], [nome_deposito], [disponivel], [disponivel_transferencia], [disponivel_franquias], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_deposito, @nome_deposito, @disponivel, @disponivel_transferencia, @disponivel_franquias, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
