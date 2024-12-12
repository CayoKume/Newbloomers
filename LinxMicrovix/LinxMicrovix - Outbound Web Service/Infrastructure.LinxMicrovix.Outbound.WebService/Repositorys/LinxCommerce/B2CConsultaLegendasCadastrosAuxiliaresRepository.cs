using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliaresRepository : IB2CConsultaLegendasCadastrosAuxiliaresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaLegendasCadastrosAuxiliares> _linxMicrovixRepositoryBase;


        public B2CConsultaLegendasCadastrosAuxiliaresRepository(ILinxMicrovixRepositoryBase<B2CConsultaLegendasCadastrosAuxiliares> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaLegendasCadastrosAuxiliares> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaLegendasCadastrosAuxiliares());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].empresa, records[i].legenda_setor, records[i].legenda_linha, records[i].legenda_marca, records[i].legenda_colecao, records[i].legenda_grade1, records[i].legenda_grade2,
                        records[i].legenda_espessura, records[i].legenda_classificacao, records[i].timestamp);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTALEGENDASCADASTROSAUXILIARES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTALEGENDASCADASTROSAUXILIARES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTALEGENDASCADASTROSAUXILIARES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTALEGENDASCADASTROSAUXILIARES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[LEGENDA_SETOR] = SOURCE.[LEGENDA_SETOR],
			                           TARGET.[LEGENDA_LINHA] = SOURCE.[LEGENDA_LINHA],
			                           TARGET.[LEGENDA_MARCA] = SOURCE.[LEGENDA_MARCA],
			                           TARGET.[LEGENDA_COLECAO] = SOURCE.[LEGENDA_COLECAO],
			                           TARGET.[LEGENDA_GRADE1] = SOURCE.[LEGENDA_GRADE1],
			                           TARGET.[LEGENDA_GRADE2] = SOURCE.[LEGENDA_GRADE2],
			                           TARGET.[LEGENDA_ESPESSURA] = SOURCE.[LEGENDA_ESPESSURA],
			                           TARGET.[LEGENDA_CLASSIFICACAO] = SOURCE.[LEGENDA_CLASSIFICACAO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[EMPRESA] NOT IN (SELECT [EMPRESA] FROM [B2CCONSULTALEGENDASCADASTROSAUXILIARES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [EMPRESA], [LEGENDA_SETOR], [LEGENDA_LINHA], [LEGENDA_MARCA], [LEGENDA_COLECAO], [LEGENDA_GRADE1], [LEGENDA_GRADE2],
			                           [LEGENDA_ESPESSURA], [LEGENDA_CLASSIFICACAO], [TIMESTAMP])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[EMPRESA], SOURCE.[LEGENDA_SETOR], SOURCE.[LEGENDA_LINHA], SOURCE.[LEGENDA_MARCA], SOURCE.[LEGENDA_COLECAO], 
			                           SOURCE.[LEGENDA_GRADE1], SOURCE.[LEGENDA_GRADE2], SOURCE.[LEGENDA_ESPESSURA], SOURCE.[LEGENDA_CLASSIFICACAO], SOURCE.[TIMESTAMP]);
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

        public async Task<List<B2CConsultaLegendasCadastrosAuxiliares>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaLegendasCadastrosAuxiliares> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].empresa}'";
                    else
                        identificadores += $"'{registros[i].empresa}', ";
                }

                string sql = $"SELECT EMPRESA, TIMESTAMP FROM B2CCONSULTALEGENDASCADASTROSAUXILIARES_TRUSTED WHERE EMPRESA IN ({identificadores})";

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
                        individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
