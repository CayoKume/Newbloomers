using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaNFeRepository : IB2CConsultaNFeRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaNFe> _linxMicrovixRepositoryBase;

        public B2CConsultaNFeRepository(ILinxMicrovixRepositoryBase<B2CConsultaNFe> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaNFe> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaNFe());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_nfe, records[i].id_pedido, records[i].documento, records[i].data_emissao, records[i].chave_nfe, records[i].situacao, records[i].xml,
                        records[i].excluido, records[i].identificador_microvix, records[i].dt_insert, records[i].valor_nota, records[i].serie, records[i].frete, records[i].timestamp, records[i].portal, 
                        records[i].nProt, records[i].codigo_modelo_nf, records[i].justificativa, records[i].tpAmb);
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTANFE_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTANFE_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTANFE_TRUSTED] AS TARGET
                                   USING [B2CCONSULTANFE_RAW] AS SOURCE

                                   ON (TARGET.[ID_NFE] = SOURCE.[ID_NFE])

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_NFE] = SOURCE.[ID_NFE],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[DOCUMENTO] = SOURCE.[DOCUMENTO],
			                           TARGET.[DATA_EMISSAO] = SOURCE.[DATA_EMISSAO],
			                           TARGET.[CHAVE_NFE] = SOURCE.[CHAVE_NFE],
			                           TARGET.[SITUACAO] = SOURCE.[SITUACAO],
			                           TARGET.[XML] = SOURCE.[XML],
			                           TARGET.[EXCLUIDO] = SOURCE.[EXCLUIDO],
			                           TARGET.[IDENTIFICADOR_MICROVIX] = SOURCE.[IDENTIFICADOR_MICROVIX],
			                           TARGET.[DT_INSERT] = SOURCE.[DT_INSERT],
			                           TARGET.[VALOR_NOTA] = SOURCE.[VALOR_NOTA],
			                           TARGET.[SERIE] = SOURCE.[SERIE],
			                           TARGET.[FRETE] = SOURCE.[FRETE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[NPROT] = SOURCE.[NPROT],
			                           TARGET.[CODIGO_MODELO_NF] = SOURCE.[CODIGO_MODELO_NF],
			                           TARGET.[JUSTIFICATIVA] = SOURCE.[JUSTIFICATIVA],
			                           TARGET.[TPAMB] = SOURCE.[TPAMB]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_NFE] NOT IN (SELECT [ID_NFE] FROM [B2CCONSULTANFE_TRUSTED]) THEN
                                       INSERT
                                       ([LASTUPDATEON], [ID_NFE], [ID_PEDIDO], [DOCUMENTO], [DATA_EMISSAO], [CHAVE_NFE], [SITUACAO], [XML], [EXCLUIDO], [IDENTIFICADOR_MICROVIX], [DT_INSERT], [VALOR_NOTA], [SERIE], [FRETE], [TIMESTAMP], [PORTAL], [NPROT], [CODIGO_MODELO_NF], [TPAMB])
                                       VALUES
                                       (SOURCE.[LASTUPDATEON], SOURCE.[ID_NFE], SOURCE.[ID_PEDIDO], SOURCE.[DOCUMENTO], SOURCE.[DATA_EMISSAO], SOURCE.[CHAVE_NFE], SOURCE.[SITUACAO], SOURCE.[XML], SOURCE.[EXCLUIDO], SOURCE.[IDENTIFICADOR_MICROVIX], SOURCE.[DT_INSERT],
                                       SOURCE.[VALOR_NOTA], SOURCE.[SERIE], SOURCE.[FRETE], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[NPROT], SOURCE.[CODIGO_MODELO_NF], SOURCE.[TPAMB]);
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

        public async Task<List<B2CConsultaNFe>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaNFe> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_nfe}'";
                    else
                        identificadores += $"'{registros[i].id_nfe}', ";
                }

                string sql = $"SELECT ID_NFE, TIMESTAMP FROM B2CCONSULTANFE_TRUSTED WHERE ID_NFE IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaNFe? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_nfe], [id_pedido], [documento], [data_emissao], [chave_nfe], [situacao], [xml], [excluido], [identificador_microvix], [dt_insert], [valor_nota], [serie], [frete], [timestamp], [portal], [nProt], [codigo_modelo_nf], [justificativa], [tpAmb]) " +
                          "Values " +
                          "(@lastupdateon, @id_nfe, @id_pedido, @documento, @data_emissao, @chave_nfe, @situacao, @xml, @excluido, @identificador_microvix, @dt_insert, @valor_nota, @serie, @frete, @timestamp, @portal, @nProt, @codigo_modelo_nf, @justificativa, @tpAmb)";

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
