using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
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
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClientesSaldo());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].saldo, records[i].cod_cliente_erp, records[i].empresa, records[i].timestamp, records[i].portal);
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

        public async Task<bool> CreateTableMerge(LinxAPIParam jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESSALDO_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESSALDO_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESSALDO] AS TARGET
                                   USING [B2CCONSULTACLIENTESSALDO] AS SOURCE

                                   ON (
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[SALDO] = SOURCE.[SALDO],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[COD_CLIENTE_ERP] NOT IN (SELECT [COD_CLIENTE_ERP] FROM [B2CCONSULTACLIENTESSALDO]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [SALDO], [COD_CLIENTE_ERP], [EMPRESA], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[SALDO], SOURCE.[COD_CLIENTE_ERP], SOURCE.[EMPRESA], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaClientesSaldo>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesSaldo> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].cod_cliente_erp}'";
                    else
                        identificadores += $"'{registros[i].cod_cliente_erp}', ";
                }

                string sql = $"SELECT COD_CLIENTE_ERP, TIMESTAMP FROM B2CCONSULTACLIENTESSALDO WHERE COD_CLIENTE_ERP IN ({identificadores})";

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

        public async Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesSaldo? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [saldo], [cod_cliente_erp], [empresa], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @saldo, @cod_cliente_erp, @empresa, @timestamp, @portal)";

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
