using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesSaldoRepository : IB2CConsultaClientesSaldoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesSaldo> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesSaldoRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientesSaldo> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesSaldo> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaClientesSaldo());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].saldo, records[i].cod_cliente_erp, records[i].empresa, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesSaldo> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].cod_cliente_erp}'";
                else
                    identificadores += $"'{registros[i].cod_cliente_erp}', ";
            }

            string sql = $"SELECT CONCAT('[', COD_CLIENTE_ERP, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESSALDO] WHERE COD_CLIENTE_ERP IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesSaldo? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [saldo], [cod_cliente_erp], [empresa], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @saldo, @cod_cliente_erp, @empresa, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
