using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorRepository<TEntity> : IB2CConsultaPedidosIdentificadorRepository<TEntity> where TEntity : B2CConsultaPedidosIdentificador, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosIdentificadorRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].empresa, records[i].identificador, records[i].id_venda, records[i].order_id, records[i].id_cliente, records[i].valor_frete,
                        records[i].data_origem, records[i].timestamp);
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

        public async Task<bool> ExecuteTableMerge(JobParameter jobParameter)
        {
            string sql = $"MERGE [{jobParameter.tableName}_trusted] AS TARGET " +
                         $"USING [{jobParameter.tableName}_raw] AS SOURCE " +
                          "ON (TARGET.ID_VENDA = SOURCE.ID_VENDA) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL], " +
                          "TARGET.[EMPRESA] = SOURCE.[EMPRESA], " +
                          "TARGET.[IDENTIFICADOR] = SOURCE.[IDENTIFICADOR], " +
                          "TARGET.[ID_VENDA] = SOURCE.[ID_VENDA], " +
                          "TARGET.[ORDER_ID] = SOURCE.[ORDER_ID], " +
                          "TARGET.[ID_CLIENTE] = SOURCE.[ID_CLIENTE], " +
                          "TARGET.[VALOR_FRETE] = SOURCE.[VALOR_FRETE], " +
                          "TARGET.[DATA_ORIGEM] = SOURCE.[DATA_ORIGEM], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [PORTAL], [EMPRESA], [IDENTIFICADOR], [ID_VENDA], [ORDER_ID], [ID_CLIENTE], [VALOR_FRETE], [DATA_ORIGEM], [TIMESTAMP])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[EMPRESA], SOURCE.[IDENTIFICADOR], SOURCE.[ID_VENDA], SOURCE.[ORDER_ID], SOURCE.[ID_CLIENTE], SOURCE.[VALOR_FRETE], SOURCE.[DATA_ORIGEM], SOURCE.[TIMESTAMP]);";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(JobParameter jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                    <Parameter id=""data_origem_fim"">[data_origem_fim]</Parameter>
                                                    <Parameter id=""data_origem_inicial"">[data_origem_inicial]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""order_id"">[order_id]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(JobParameter jobParameter, TEntity? record)
        {
            string sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [portal], [empresa], [identificador], [id_venda], [order_id], [id_cliente], [valor_frete], [data_origem], [timestamp]) " +
                          "Values " +
                          "(@lastupdateon, @portal, @empresa, @identificador, @id_venda, @order_id, @id_cliente, @valor_frete, @data_origem, @timestamp)";

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
