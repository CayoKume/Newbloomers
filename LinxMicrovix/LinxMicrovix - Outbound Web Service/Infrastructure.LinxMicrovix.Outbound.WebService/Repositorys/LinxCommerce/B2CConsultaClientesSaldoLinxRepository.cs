using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinxRepository : IB2CConsultaClientesSaldoLinxRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesSaldoLinx> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesSaldoLinxRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientesSaldoLinx> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaClientesSaldoLinx> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClientesSaldoLinx());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].empresa, records[i].valor, records[i].timestamp, records[i].portal);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESSALDOLINX_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESSALDOLINX_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESSALDOLINX_TRUSTED] AS TARGET
                                   USING [B2CCONSULTACLIENTESSALDOLINX_RAW] AS SOURCE

                                   ON (
			                           TARGET.[COD_CLIENTE_B2C] = SOURCE.[COD_CLIENTE_B2C]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[COD_CLIENTE_B2C] = SOURCE.[COD_CLIENTE_B2C],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[VALOR] = SOURCE.[VALOR],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[COD_CLIENTE_B2C] NOT IN (SELECT [COD_CLIENTE_B2C] FROM [B2CCONSULTACLIENTESSALDOLINX_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [COD_CLIENTE_ERP], [COD_CLIENTE_B2C], [EMPRESA], [VALOR], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[COD_CLIENTE_ERP], SOURCE.[COD_CLIENTE_B2C], SOURCE.[EMPRESA], SOURCE.[VALOR], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                                                  <Parameter id=""cod_cliente_erp"">[cod_cliente_erp]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaClientesSaldoLinx? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [cod_cliente_erp], [cod_cliente_b2c], [empresa], [valor], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_cliente_erp, @cod_cliente_b2c, @empresa, @valor, @timestamp, @portal)";

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
