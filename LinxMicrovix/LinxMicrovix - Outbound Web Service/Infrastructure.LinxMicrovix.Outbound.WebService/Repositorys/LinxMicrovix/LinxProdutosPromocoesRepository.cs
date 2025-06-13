using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosPromocoesRepository : ILinxProdutosPromocoesRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosPromocoes> _linxMicrovixRepositoryBase;

        public LinxProdutosPromocoesRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosPromocoes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosPromocoes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosPromocoes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_produto, records[i].preco_promocao, records[i].data_inicio_promocao,
                        records[i].data_termino_promocao, records[i].data_cadastro_promocao, records[i].promocao_ativa, records[i].id_campanha, records[i].nome_campanha, records[i].promocao_opcional,
                        records[i].custo_total_campanha);
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

        public async Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros)
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

                        string sql = $"SELECT CONCAT('[', PORTAL, ']', '|', '[', CNPJ_EMP, ']', '|', '[', COD_PRODUTO, ']', '|', '[', PRECO_PROMOCAO, ']', '|', '[', DATA_INICIO_PROMOCAO, ']', '|', '[', DATA_TERMINO_PROMOCAO, ']', '|', '[', DATA_CADASTRO_PROMOCAO , ']', '|', '[', PROMOCAO_ATIVA, ']', '|', '[', ID_CAMPANHA, ']', '|', '[', NOME_CAMPANHA, ']', '|', '[', PROMOCAO_OPCIONAL, ']', '|', '[', CUSTO_TOTAL_CAMPANHA, ']') FROM [linx_microvix_erp].[LinxProdutosPromocoes] WHERE cod_produto IN ({identificadores})";
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

                    string sql = $"SELECT CONCAT('[', PORTAL, ']', '|', '[', CNPJ_EMP, ']', '|', '[', COD_PRODUTO, ']', '|', '[', PRECO_PROMOCAO, ']', '|', '[', DATA_INICIO_PROMOCAO, ']', '|', '[', DATA_TERMINO_PROMOCAO, ']', '|', '[', DATA_CADASTRO_PROMOCAO , ']', '|', '[', PROMOCAO_ATIVA, ']', '|', '[', ID_CAMPANHA, ']', '|', '[', NOME_CAMPANHA, ']', '|', '[', PROMOCAO_OPCIONAL, ']', '|', '[', CUSTO_TOTAL_CAMPANHA, ']') FROM [linx_microvix_erp].[LinxProdutosPromocoes] WHERE cod_produto IN ({identificadores})";
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosPromocoes? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[portal],[cnpj_emp],[cod_produto],[preco_promocao],[data_inicio_promocao],[data_termino_promocao],[data_cadastro_promocao],[promocao_ativa],
                             [id_campanha],[nome_campanha],[promocao_opcional],[custo_total_campanha])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@cod_produto,@preco_promocao,@data_inicio_promocao,@data_termino_promocao,@data_cadastro_promocao,@promocao_ativa,@id_campanha,
                             @nome_campanha,@promocao_opcional,@custo_total_campanha)";

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
