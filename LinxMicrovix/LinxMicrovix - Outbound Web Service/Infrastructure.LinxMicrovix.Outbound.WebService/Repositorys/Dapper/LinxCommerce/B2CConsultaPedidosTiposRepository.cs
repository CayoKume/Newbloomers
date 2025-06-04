using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaPedidosTiposRepository : IB2CConsultaPedidosTiposRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaPedidosTipos> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosTiposRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaPedidosTipos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosTipos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPedidosTipos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_tipo_b2c, records[i].descricao, records[i].pos_timestamp_old, records[i].portal);
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

        public async Task<List<B2CConsultaPedidosTipos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPedidosTipos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_tipo_b2c}'";
                    else
                        identificadores += $"'{registros[i].id_tipo_b2c}', ";
                }

                string sql = $"SELECT ID_TIPO_B2C, TIMESTAMP FROM B2CCONSULTAPEDIDOSTIPOS WHERE ID_TIPO_B2C IN ({identificadores})";

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
    }
}
