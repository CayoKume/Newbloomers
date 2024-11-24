using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPedidosPlanosRepository : IB2CConsultaPedidosPlanosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosPlanos> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosPlanosRepository(ILinxMicrovixRepositoryBase<B2CConsultaPedidosPlanos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaPedidosPlanos> records)
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

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOSPLANOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOSPLANOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPEDIDOSPLANOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPEDIDOSPLANOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PEDIDO_PLANOS] = SOURCE.[ID_PEDIDO_PLANOS]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PEDIDO_PLANOS] = SOURCE.[ID_PEDIDO_PLANOS],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[PLANO_PAGAMENTO] = SOURCE.[PLANO_PAGAMENTO],
			                           TARGET.[VALOR_PLANO] = SOURCE.[VALOR_PLANO],
			                           TARGET.[NSU_SITEF] = SOURCE.[NSU_SITEF],
			                           TARGET.[COD_AUTORIZACAO] = SOURCE.[COD_AUTORIZACAO],
			                           TARGET.[TEXTO_COMPROVANTE] = SOURCE.[TEXTO_COMPROVANTE],
			                           TARGET.[COD_LOJA_SITEF] = SOURCE.[COD_LOJA_SITEF],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PEDIDO_PLANOS] NOT IN (SELECT [ID_PEDIDO_PLANOS] FROM [B2CCONSULTAPEDIDOSPLANOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PEDIDO_PLANOS], [ID_PEDIDO], [PLANO_PAGAMENTO], [VALOR_PLANO], [NSU_SITEF], [COD_AUTORIZACAO], [TEXTO_COMPROVANTE], [COD_LOJA_SITEF], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PEDIDO_PLANOS], SOURCE.[ID_PEDIDO], SOURCE.[PLANO_PAGAMENTO], SOURCE.[VALOR_PLANO], SOURCE.[NSU_SITEF], SOURCE.[COD_AUTORIZACAO], SOURCE.[TEXTO_COMPROVANTE], SOURCE.[COD_LOJA_SITEF], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaPedidosPlanos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaPedidosPlanos> registros)
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

                string sql = $"SELECT ID_PEDIDO_PLANOS, TIMESTAMP FROM B2CCONSULTAPEDIDOSPLANOS_TRUSTED WHERE ID_PEDIDO_PLANOS IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaPedidosPlanos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
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
