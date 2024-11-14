using Domain.IntegrationsCore.Entities.Parameters;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaVendedoresRepository : IB2CConsultaVendedoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaVendedores> _linxMicrovixRepositoryBase;

        public B2CConsultaVendedoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaVendedores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaVendedores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaVendedores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_vendedor, records[i].nome_vendedor, records[i].comissao_produtos, records[i].comissao_servicos, records[i].tipo, records[i].ativo, records[i].comissionado, records[i].timestamp, records[i].portal);
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
            string? sql = $"MERGE [{jobParameter.tableName}_trusted] AS TARGET " +
                         $"USING [{jobParameter.tableName}_raw] AS SOURCE " +
                          "ON (TARGET.COD_VENDEDOR = SOURCE.COD_VENDEDOR) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[COD_VENDEDOR] = SOURCE.[COD_VENDEDOR], " +
                          "TARGET.[NOME_VENDEDOR] = SOURCE.[NOME_VENDEDOR], " +
                          "TARGET.[COMISSAO_SERVICOS] = SOURCE.[COMISSAO_SERVICOS], " +
                          "TARGET.[TIPO] = SOURCE.[TIPO], " +
                          "TARGET.[ATIVO] = SOURCE.[ATIVO], " +
                          "TARGET.[COMISSIONADO] = SOURCE.[COMISSIONADO], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [COD_VENDEDOR], [NOME_VENDEDOR], [COMISSAO_SERVICOS], [TIPO], [ATIVO], [COMISSIONADO], [TIMESTAMP], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[COD_VENDEDOR], SOURCE.[NOME_VENDEDOR], SOURCE.[COMISSAO_SERVICOS], SOURCE.[TIPO], SOURCE.[ATIVO], SOURCE.[COMISSIONADO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

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
                                                  <Parameter id=""cod_vendedor"">[cod_vendedor]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaVendedores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [cod_vendedor], [nome_vendedor], [comissao_produtos], [comissao_servicos], [tipo], [ativo], [comissionado], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_vendedor, @nome_vendedor, @comissao_produtos, @comissao_servicos, @tipo, @ativo, @comissionado, @timestamp, @portal)";

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
