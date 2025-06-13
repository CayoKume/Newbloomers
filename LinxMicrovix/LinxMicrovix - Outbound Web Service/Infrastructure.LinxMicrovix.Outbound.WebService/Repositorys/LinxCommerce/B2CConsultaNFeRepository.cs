using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaNFeRepository : IB2CConsultaNFeRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaNFe> _linxMicrovixRepositoryBase;

        public B2CConsultaNFeRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaNFe> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaNFe> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaNFe());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_nfe, records[i].id_pedido, records[i].documento, records[i].data_emissao, records[i].chave_nfe, records[i].situacao, records[i].xml,
                        records[i].excluido, records[i].identificador_microvix, records[i].dt_insert, records[i].valor_nota, records[i].serie, records[i].frete, records[i].timestamp, records[i].portal,
                        records[i].nProt, records[i].codigo_modelo_nf, records[i].justificativa, records[i].tpAmb);
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

        public async Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 1)
                {
                    var list = new List<string?>();

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

                        string sql = $"SELECT CONCAT('[', ID_NFE, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CHAVE_NFE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTANFE] WHERE ID_NFE IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var list = new List<string?>();
                    string identificadores = String.Empty;

                    for (int i = 0; i < registros.Count(); i++)
                    {

                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i]}'";
                        else
                            identificadores += $"'{registros[i]}', ";
                    }

                    string sql = $"SELECT CONCAT('[', ID_NFE, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CHAVE_NFE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTANFE] WHERE ID_NFE IN ({identificadores})";
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaNFe? record)
        {
            string? sql = $"INSERT INTO [untreated].{jobParameter.tableName} " +
                          "([lastupdateon], [id_nfe], [id_pedido], [documento], [data_emissao], [chave_nfe], [situacao], [xml], [excluido], [identificador_microvix], [dt_insert], [valor_nota], [serie], [frete], [timestamp], [portal], [nProt], [codigo_modelo_nf], [justificativa], [tpAmb]) " +
                          "Values " +
                          "(@lastupdateon, @id_nfe, @id_pedido, @documento, @data_emissao, @chave_nfe, @situacao, @xml, @excluido, @identificador_microvix, @dt_insert, @valor_nota, @serie, @frete, @timestamp, @portal, @nProt, @codigo_modelo_nf, @justificativa, @tpAmb)";

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
