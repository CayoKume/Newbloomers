using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinxRepository : IB2CConsultaClientesSaldoLinxRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaClientesSaldoLinx> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesSaldoLinxRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaClientesSaldoLinx> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesSaldoLinx> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaClientesSaldoLinx());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].empresa, records[i].valor, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaClientesSaldoLinx>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesSaldoLinx> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].cod_cliente_b2c}'";
                    else
                        identificadores += $"'{registros[i].cod_cliente_b2c}', ";
                }

                string sql = $"SELECT COD_CLIENTE_B2C, TIMESTAMP FROM B2CCONSULTACLIENTESSALDOLINX WHERE COD_CLIENTE_B2C IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesSaldoLinx? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [cod_cliente_erp], [cod_cliente_b2c], [empresa], [valor], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_cliente_erp, @cod_cliente_b2c, @empresa, @valor, @timestamp, @portal)";

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
