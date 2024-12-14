using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClassificacaoRepository : IB2CConsultaClassificacaoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClassificacao> _linxMicrovixRepositoryBase;

        public B2CConsultaClassificacaoRepository (ILinxMicrovixRepositoryBase<B2CConsultaClassificacao> linxMicrovixRepositoryBase)  =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClassificacao> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClassificacao());

                for(int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_classificacao, records[i].nome_classificacao, records[i].timestamp, records[i].portal);
                };

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLASSIFICACAO_SYNC')
                           BEGIN
                           EXECUTE (
                               'CREATE PROCEDURE [P_B2CCONSULTACLASSIFICACAO_SYNC] AS
                               BEGIN
	                               MERGE [B2CCONSULTACLASSIFICACAO] AS TARGET 
	                               USING [B2CCONSULTACLASSIFICACAO] AS SOURCE 

	                               ON (
                                        TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO]
                                   ) 
	                           
                                   WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
                                       UPDATE SET 
	                                   TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], 
	                                   TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO], 
	                                   TARGET.[NOME_CLASSIFICACAO] = SOURCE.[NOME_CLASSIFICACAO], 
	                                   TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], 
	                                   TARGET.[PORTAL] = SOURCE.[PORTAL] 
	                           
                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_CLASSIFICACAO] NOT IN (SELECT [CODIGO_CLASSIFICACAO] FROM [B2CCONSULTACLASSIFICACAO]) THEN 
	                                   INSERT ([LASTUPDATEON], [CODIGO_CLASSIFICACAO], [NOME_CLASSIFICACAO], [TIMESTAMP], [PORTAL])
	                                   VALUES (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_CLASSIFICACAO], SOURCE.[NOME_CLASSIFICACAO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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

        public async Task<List<B2CConsultaClassificacao>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClassificacao> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_classificacao}'";
                    else
                        identificadores += $"'{registros[i].codigo_classificacao}', ";
                }

                string sql = $"SELECT CODIGO_CLASSIFICACAO, TIMESTAMP FROM B2CCONSULTACLASSIFICACAO WHERE CODIGO_CLASSIFICACAO IN ({identificadores})";

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
                                       <Parameter id=""codigo_classificacao"">[codigo_classificacao]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClassificacao? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_classificacao], [nome_classificacao], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_classificacao, @nome_classificacao, @timestamp, @portal)";

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
