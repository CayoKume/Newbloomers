using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPedidosPlanosRepository : IB2CConsultaPedidosPlanosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosPlanos> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosPlanosRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidosPlanos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosPlanos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPedidosPlanos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido_planos, records[i].id_pedido, records[i].plano_pagamento, records[i].valor_plano, records[i].nsu_sitef, records[i].cod_autorizacao, records[i].texto_comprovante,
                        records[i].cod_loja_sitef, records[i].timestamp, records[i].portal);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
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

        public async Task<List<B2CConsultaPedidosPlanos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPedidosPlanos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_pedido_planos}'";
                    else
                        identificadores += $"'{registros[i].id_pedido_planos}', ";
                }

                string sql = $"SELECT ID_PEDIDO_PLANOS, TIMESTAMP FROM B2CCONSULTAPEDIDOSPLANOS WHERE ID_PEDIDO_PLANOS IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPedidosPlanos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_pedido_planos], [id_pedido], [plano_pagamento], [valor_plano], [nsu_sitef], [cod_autorizacao], [texto_comprovante], [cod_loja_sitef], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido_planos, @id_pedido, @plano_pagamento, @valor_plano, @nsu_sitef, @cod_autorizacao, @texto_comprovante, @cod_loja_sitef, @timestamp, @portal)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
