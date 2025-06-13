using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public async Task<List<string>> GetRegistersExists(LinxAPIParam jobParameter, List<string?> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 1)
                {
                    var list = new List<string>();

                    for (int i = 0; i <= indice; i++)
                    {
                        string identificadores = String.Empty;
                        var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                        for (int j = 0; j < top1000List.Count(); j++)
                        {

                            if (j == top1000List.Count() - 1)
                                identificadores += $"'{top1000List[j]}'";
                            else
                                identificadores += $"'{top1000List[j]}', ";
                        }

                        string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', DOCUMENTO, ']', '|', '[', CHAVE_NFE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxXMLDocumentos] WHERE CHAVE_NFE IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var list = new List<string>();
                    string identificadores = String.Empty;

                    for (int i = 0; i < registros.Count(); i++)
                    {

                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i]}'";
                        else
                            identificadores += $"'{registros[i]}', ";
                    }

                    string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', DOCUMENTO, ']', '|', '[', CHAVE_NFE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxXMLDocumentos] WHERE CHAVE_NFE IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                    list.AddRange(result);

                    return list;
                }
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
