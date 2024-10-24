using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCustosRepository<TEntity> : IB2CConsultaProdutosCustosRepository<TEntity> where TEntity : B2CConsultaProdutosCustos, new()
    {
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCustosRepository(ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(JobParameter jobParameter, List<TEntity> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new TEntity());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_produtos_custos, records[i].codigoproduto, records[i].empresa, records[i].custoicms1, records[i].ipi1, records[i].markup, records[i].customedio,
                        records[i].frete1, records[i].precisao, records[i].precominimo, records[i].dt_update, records[i].custoliquido, records[i].precovenda, records[i].custototal, records[i].precocompra, records[i].timestamp, records[i].portal);
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
                          "ON (TARGET.ID_PRODUTOS_CUSTOS = SOURCE.ID_PRODUTOS_CUSTOS) " +
                          "WHEN MATCHED THEN UPDATE SET " +
                          "TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], " +
                          "TARGET.[ID_PRODUTOS_CUSTOS] = SOURCE.[ID_PRODUTOS_CUSTOS], " +
                          "TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO], " +
                          "TARGET.[EMPRESA] = SOURCE.[EMPRESA], " +
                          "TARGET.[CUSTOICMS1] = SOURCE.[CUSTOICMS1], " +
                          "TARGET.[IPI1] = SOURCE.[IPI1], " +
                          "TARGET.[MARKUP] = SOURCE.[MARKUP], " +
                          "TARGET.[CUSTOMEDIO] = SOURCE.[CUSTOMEDIO], " +
                          "TARGET.[FRETE1] = SOURCE.[FRETE1], " +
                          "TARGET.[PRECISAO] = SOURCE.[PRECISAO], " +
                          "TARGET.[PRECOMINIMO] = SOURCE.[PRECOMINIMO], " +
                          "TARGET.[DT_UPDATE] = SOURCE.[DT_UPDATE], " +
                          "TARGET.[CUSTOLIQUIDO] = SOURCE.[CUSTOLIQUIDO], " +
                          "TARGET.[PRECOVENDA] = SOURCE.[PRECOVENDA], " +
                          "TARGET.[CUSTOTOTAL] = SOURCE.[CUSTOTOTAL], " +
                          "TARGET.[PRECOCOMPRA] = SOURCE.[PRECOCOMPRA], " +
                          "TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], " +
                          "TARGET.[PORTAL] = SOURCE.[PORTAL] " +
                          "WHEN NOT MATCHED BY TARGET THEN " +
                          "INSERT " +
                          "([LASTUPDATEON], [ID_PRODUTOS_CUSTOS], [CODIGOPRODUTO], [EMPRESA], [CUSTOICMS1], [IPI1], [MARKUP], [CUSTOMEDIO], [FRETE1], [PRECISAO], [PRECOMINIMO], [DT_UPDATE], [CUSTOLIQUIDO], [PRECOVENDA], [CUSTOTOTAL], [PRECOCOMPRA], [TIMESTAMP], [PORTAL])" +
                          "VALUES " +
                          "(SOURCE.[LASTUPDATEON], SOURCE.[ID_PRODUTOS_CUSTOS], SOURCE.[CODIGOPRODUTO], SOURCE.[EMPRESA], SOURCE.[CUSTOICMS1], SOURCE.[IPI1], SOURCE.[MARKUP], SOURCE.[CUSTOMEDIO], SOURCE.[FRETE1], SOURCE.[PRECISAO], SOURCE.[PRECOMINIMO], " +
                          "SOURCE.[DT_UPDATE], SOURCE.[CUSTOLIQUIDO], SOURCE.[PRECOVENDA], SOURCE.[CUSTOTOTAL], SOURCE.[PRECOCOMPRA], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);";

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
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>",
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
                          "([lastupdateon], [id_produtos_custos], [codigoproduto], [empresa], [custoicms1], [ipi1], [markup], [customedio], [frete1], [precisao], [precominimo], [dt_update], [custoliquido], [precovenda], [custototal], [precocompra], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_produtos_custos, @codigoproduto, @empresa, @custoicms1, @ipi1, @markup, @customedio, @frete1, @precisao, @precominimo, @dt_update, @custoliquido, @precovenda, @custototal, @precocompra, @timestamp, @portal)";

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
