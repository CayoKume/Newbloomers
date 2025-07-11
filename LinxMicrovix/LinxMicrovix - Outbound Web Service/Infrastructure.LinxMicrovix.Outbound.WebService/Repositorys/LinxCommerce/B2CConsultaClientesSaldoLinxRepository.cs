using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinxRepository : IB2CConsultaClientesSaldoLinxRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesSaldoLinx> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesSaldoLinxRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientesSaldoLinx> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesSaldoLinx> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaClientesSaldoLinx());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].empresa, records[i].valor, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesSaldoLinx> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].cod_cliente_b2c}'";
                else
                    identificadores += $"'{registros[i].cod_cliente_b2c}', ";
            }

            string sql = $"SELECT CONCAT('[', COD_CLIENTE_B2C, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESSALDOLINX] WHERE COD_CLIENTE_B2C IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesSaldoLinx? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [cod_cliente_erp], [cod_cliente_b2c], [empresa], [valor], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_cliente_erp, @cod_cliente_b2c, @empresa, @valor, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
