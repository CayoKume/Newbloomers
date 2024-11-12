using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix_Outbound_Web_Service.Repository.LinxCommerce
{
    public class B2CConsultaPedidosRepository : IB2CConsultaPedidosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidos> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);
        
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaPedidos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaPedidos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido, records[i].dt_pedido, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].vl_frete, records[i].forma_pgto, records[i].plano_pagamento,
                        records[i].anotacao, records[i].taxa_impressao, records[i].finalizado, records[i].valor_frete_gratis, records[i].tipo_frete, records[i].id_status, records[i].cod_transportador, records[i].tipo_cobranca_frete, 
                        records[i].ativo, records[i].empresa, records[i].id_tabela_preco, records[i].valor_credito, records[i].cod_vendedor, records[i].timestamp, records[i].dt_insert, records[i].dt_disponivel_faturamento, records[i].portal, 
                        records[i].mensagem_falha_faturamento, records[i].id_tipo_b2c, records[i].ecommerce_origem, records[i].order_id);
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

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPEDIDOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPEDIDOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[DT_PEDIDO] = SOURCE.[DT_PEDIDO],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[COD_CLIENTE_B2C] = SOURCE.[COD_CLIENTE_B2C],
			                           TARGET.[VL_FRETE] = SOURCE.[VL_FRETE],
			                           TARGET.[FORMA_PGTO] = SOURCE.[FORMA_PGTO],
			                           TARGET.[PLANO_PAGAMENTO] = SOURCE.[PLANO_PAGAMENTO],
			                           TARGET.[ANOTACAO] = SOURCE.[ANOTACAO],
			                           TARGET.[TAXA_IMPRESSAO] = SOURCE.[TAXA_IMPRESSAO],
			                           TARGET.[FINALIZADO] = SOURCE.[FINALIZADO],
			                           TARGET.[VALOR_FRETE_GRATIS] = SOURCE.[VALOR_FRETE_GRATIS],
			                           TARGET.[TIPO_FRETE] = SOURCE.[TIPO_FRETE],
			                           TARGET.[ID_STATUS] = SOURCE.[ID_STATUS],
			                           TARGET.[COD_TRANSPORTADOR] = SOURCE.[COD_TRANSPORTADOR],
			                           TARGET.[TIPO_COBRANCA_FRETE] = SOURCE.[TIPO_COBRANCA_FRETE],
			                           TARGET.[ATIVO] = SOURCE.[ATIVO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[ID_TABELA_PRECO] = SOURCE.[ID_TABELA_PRECO],
			                           TARGET.[VALOR_CREDITO] = SOURCE.[VALOR_CREDITO],
			                           TARGET.[COD_VENDEDOR] = SOURCE.[COD_VENDEDOR],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[DT_INSERT] = SOURCE.[DT_INSERT],
			                           TARGET.[DT_DISPONIVEL_FATURAMENTO] = SOURCE.[DT_DISPONIVEL_FATURAMENTO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[MENSAGEM_FALHA_FATURAMENTO] = SOURCE.[MENSAGEM_FALHA_FATURAMENTO],
			                           TARGET.[ID_TIPO_B2C] = SOURCE.[ID_TIPO_B2C],
			                           TARGET.[ECOMMERCE_ORIGEM] = SOURCE.[ECOMMERCE_ORIGEM],
			                           TARGET.[ORDER_ID] = SOURCE.[ORDER_ID]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PEDIDO] NOT IN (SELECT [ID_PEDIDO] FROM [B2CCONSULTAPEDIDOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PEDIDO], [DT_PEDIDO], [COD_CLIENTE_ERP], [COD_CLIENTE_B2C], [VL_FRETE], [FORMA_PGTO], [PLANO_PAGAMENTO], [ANOTACAO], [TAXA_IMPRESSAO], [FINALIZADO], [VALOR_FRETE_GRATIS], [TIPO_FRETE], 
			                           [ID_STATUS], [COD_TRANSPORTADOR], [TIPO_COBRANCA_FRETE], [ATIVO], [EMPRESA], [ID_TABELA_PRECO], [VALOR_CREDITO], [COD_VENDEDOR], [TIMESTAMP], [DT_INSERT], [DT_DISPONIVEL_FATURAMENTO], [PORTAL], [MENSAGEM_FALHA_FATURAMENTO], 
			                           [ID_TIPO_B2C], [ECOMMERCE_ORIGEM], [ORDER_ID])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PEDIDO], SOURCE.[DT_PEDIDO], SOURCE.[COD_CLIENTE_ERP], SOURCE.[COD_CLIENTE_B2C], SOURCE.[VL_FRETE], SOURCE.[FORMA_PGTO], SOURCE.[PLANO_PAGAMENTO], SOURCE.[ANOTACAO], 
			                           SOURCE.[TAXA_IMPRESSAO], SOURCE.[FINALIZADO], SOURCE.[VALOR_FRETE_GRATIS], SOURCE.[TIPO_FRETE], SOURCE.[ID_STATUS], SOURCE.[COD_TRANSPORTADOR], SOURCE.[TIPO_COBRANCA_FRETE], SOURCE.[ATIVO], SOURCE.[EMPRESA],
			                           SOURCE.[ID_TABELA_PRECO], SOURCE.[VALOR_CREDITO], SOURCE.[COD_VENDEDOR], SOURCE.[TIMESTAMP], SOURCE.[DT_INSERT], SOURCE.[DT_DISPONIVEL_FATURAMENTO], SOURCE.[PORTAL], SOURCE.[MENSAGEM_FALHA_FATURAMENTO], SOURCE.[ID_TIPO_B2C], 
			                           SOURCE.[ECOMMERCE_ORIGEM], SOURCE.[ORDER_ID]);
	                           END'
                           )
                           END";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""id_pedido"">[id_pedido]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaPedidos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_pedido], [dt_pedido], [cod_cliente_erp], [cod_cliente_b2c], [vl_frete], [forma_pgto], [plano_pagamento], [anotacao], [taxa_impressao], [finalizado], [valor_frete_gratis], [tipo_frete], " +
                          "[id_status], [cod_transportador], [tipo_cobranca_frete], [ativo], [empresa], [id_tabela_preco], [valor_credito], [cod_vendedor], [timestamp], [dt_insert], [dt_disponivel_faturamento], [portal], " +
                          "[mensagem_falha_faturamento], [id_tipo_b2c], [ecommerce_origem], [order_id]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido, @dt_pedido, @cod_cliente_erp, @cod_cliente_b2c, @vl_frete, @forma_pgto, @plano_pagamento, @anotacao, @taxa_impressao, @finalizado, @valor_frete_gratis, @tipo_frete, @id_status, " +
                          "@cod_transportador, @tipo_cobranca_frete, @ativo, @empresa, @id_tabela_preco, @valor_credito, @cod_vendedor, @timestamp, @dt_insert, @dt_disponivel_faturamento, @portal, @mensagem_falha_faturamento, @id_tipo_b2c, " +
                          "@ecommerce_origem, @order_id)";

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
