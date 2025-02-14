using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxXMLDocumentosRepository : ILinxXMLDocumentosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxXMLDocumentos> _linxMicrovixRepositoryBase;

        public LinxXMLDocumentosRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxXMLDocumentos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxXMLDocumentos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxXMLDocumentos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].documento, records[i].serie, records[i].data_emissao,
                        records[i].chave_nfe, records[i].situacao, records[i].xml, records[i].excluido, records[i].identificador_microvix, records[i].dt_insert,
                        records[i].timestamp, records[i].nProtCanc, records[i].nProtInut, records[i].xmlDistribuicao, records[i].nProtDeneg, records[i].cStat, 
                        records[i].id_nfe, records[i].cod_cliente);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
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

        public async Task<List<LinxXMLDocumentos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxXMLDocumentos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].chave_nfe}'";
                    else
                        identificadores += $"'{registros[i].chave_nfe}', ";
                }

                string sql = $"SELECT chave_nfe, TIMESTAMP FROM [linx_microvix_erp].[LinxXMLDocumentos] WHERE chave_nfe IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxXMLDocumentos? record)
        {
            string? sql = @$"INSERT INTO {jobParameter.tableName} 
                            ([lastupdateon],[portal],[cnpj_emp],[documento],[serie],[data_emissao],[chave_nfe],[situacao],[xml],[excluido],[identificador_microvix],[dt_insert],[timestamp],
                             [nProtCanc],[nProtInut],[xmlDistribuicao],[nProtDeneg],[cStat],[id_nfe],[cod_cliente])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@documento,@serie,@data_emissao,@chave_nfe,@situacao,@xml,@excluido,@identificador_microvix,@dt_insert,@timestamp,@nProtCanc,
                             @nProtInut,@xmlDistribuicao,@nProtDeneg,@cStat,@id_nfe,@cod_cliente)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
