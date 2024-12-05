using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCustosRepository : IB2CConsultaProdutosCustosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCustos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCustosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCustos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaProdutosCustos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosCustos());

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

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCUSTOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCUSTOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSCUSTOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSCUSTOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PRODUTOS_CUSTOS] = SOURCE.[ID_PRODUTOS_CUSTOS]
		                           )
        
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PRODUTOS_CUSTOS] = SOURCE.[ID_PRODUTOS_CUSTOS],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[CUSTOICMS1] = SOURCE.[CUSTOICMS1],
			                           TARGET.[IPI1] = SOURCE.[IPI1],
			                           TARGET.[MARKUP] = SOURCE.[MARKUP],
			                           TARGET.[CUSTOMEDIO] = SOURCE.[CUSTOMEDIO],
			                           TARGET.[FRETE1] = SOURCE.[FRETE1],
			                           TARGET.[PRECISAO] = SOURCE.[PRECISAO],
			                           TARGET.[PRECOMINIMO] = SOURCE.[PRECOMINIMO],
			                           TARGET.[DT_UPDATE] = SOURCE.[DT_UPDATE],
			                           TARGET.[CUSTOLIQUIDO] = SOURCE.[CUSTOLIQUIDO],
			                           TARGET.[PRECOVENDA] = SOURCE.[PRECOVENDA],
			                           TARGET.[CUSTOTOTAL] = SOURCE.[CUSTOTOTAL],
			                           TARGET.[PRECOCOMPRA] = SOURCE.[PRECOCOMPRA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]
        
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PRODUTOS_CUSTOS] NOT IN (SELECT [ID_PRODUTOS_CUSTOS] FROM [B2CCONSULTAPRODUTOSCUSTOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PRODUTOS_CUSTOS], [CODIGOPRODUTO], [EMPRESA], [CUSTOICMS1], [IPI1], [MARKUP], [CUSTOMEDIO], [FRETE1], [PRECISAO], [PRECOMINIMO], [DT_UPDATE], [CUSTOLIQUIDO], [PRECOVENDA], [CUSTOTOTAL], [PRECOCOMPRA], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PRODUTOS_CUSTOS], SOURCE.[CODIGOPRODUTO], SOURCE.[EMPRESA], SOURCE.[CUSTOICMS1], SOURCE.[IPI1], SOURCE.[MARKUP], SOURCE.[CUSTOMEDIO], SOURCE.[FRETE1], SOURCE.[PRECISAO], SOURCE.[PRECOMINIMO],
			                           SOURCE.[DT_UPDATE], SOURCE.[CUSTOLIQUIDO], SOURCE.[PRECOVENDA], SOURCE.[CUSTOTOTAL], SOURCE.[PRECOCOMPRA], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaProdutosCustos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutosCustos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_produtos_custos}'";
                    else
                        identificadores += $"'{registros[i].id_produtos_custos}', ";
                }

                string sql = $"SELECT ID_PRODUTOS_CUSTOS, TIMESTAMP FROM B2CCONSULTAPRODUTOSCUSTOS_TRUSTED WHERE ID_PRODUTOS_CUSTOS IN ({identificadores})";

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
                        timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>
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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutosCustos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
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
