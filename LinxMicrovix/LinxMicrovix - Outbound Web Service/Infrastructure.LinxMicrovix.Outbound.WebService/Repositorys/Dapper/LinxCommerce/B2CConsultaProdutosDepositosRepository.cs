using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaProdutosDepositosRepository : IB2CConsultaProdutosDepositosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosDepositos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosDepositosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosDepositos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosDepositos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosDepositos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_deposito, records[i].nome_deposito, records[i].disponivel, records[i].disponivel_transferencia, records[i].disponivel_franquias, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaProdutosDepositos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosDepositos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_deposito}'";
                    else
                        identificadores += $"'{registros[i].id_deposito}', ";
                }

                string sql = $"SELECT ID_DEPOSITO, TIMESTAMP FROM B2CCONSULTAPRODUTOSDEPOSITOS WHERE ID_DEPOSITO IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosDepositos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_deposito], [nome_deposito], [disponivel], [disponivel_transferencia], [disponivel_franquias], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_deposito, @nome_deposito, @disponivel, @disponivel_transferencia, @disponivel_franquias, @timestamp, @portal)";

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
