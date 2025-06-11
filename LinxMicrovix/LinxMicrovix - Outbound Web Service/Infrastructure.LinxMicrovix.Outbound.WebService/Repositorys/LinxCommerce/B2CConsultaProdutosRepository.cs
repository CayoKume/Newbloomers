using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosRepository : IB2CConsultaProdutosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigoproduto, records[i].referencia, records[i].codauxiliar1, records[i].descricao_basica, records[i].nome_produto, records[i].peso_liquido, records[i].codigo_setor,
                        records[i].codigo_linha, records[i].codigo_marca, records[i].codigo_colecao, records[i].codigo_espessura, records[i].codigo_grade1, records[i].codigo_grade2, records[i].unidade, records[i].ativo, records[i].codigo_classificacao,
                        records[i].dt_cadastro, records[i].observacao, records[i].cod_fornecedor, records[i].dt_update, records[i].altura_para_frete, records[i].largura_para_frete, records[i].comprimento_para_frete, records[i].timestamp, records[i].peso_bruto,
                        records[i].portal, records[i].descricao_completa_commerce, records[i].canais_ecommerce_publicados, records[i].inicio_publicacao_produto, records[i].fim_publicacao_produto, records[i].codigo_integracao_oms);
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

        public async Task<List<B2CConsultaProdutos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigoproduto}'";
                    else
                        identificadores += $"'{registros[i].codigoproduto}', ";
                }

                string sql = $"SELECT CODIGOPRODUTO, TIMESTAMP FROM B2CCONSULTAPRODUTOS WHERE CODIGOPRODUTO IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigoproduto], [referencia], [codauxiliar1], [descricao_basica], [nome_produto], [peso_liquido], [codigo_setor], [codigo_linha], [codigo_marca], [codigo_colecao], [codigo_espessura], [codigo_grade1], [codigo_grade2], [unidade], [ativo], [codigo_classificacao], [dt_cadastro], [observacao], [cod_fornecedor], [dt_update], [altura_para_frete], [largura_para_frete], [comprimento_para_frete], [timestamp], [peso_bruto], [portal], [descricao_completa_commerce], [canais_ecommerce_publicados], [inicio_publicacao_produto], [fim_publicacao_produto], [codigo_integracao_oms]) " +
                          "Values " +
                          "(@lastupdateon, @codigoproduto, @referencia, @codauxiliar1, @descricao_basica, @nome_produto, @peso_liquido, @codigo_setor, @codigo_linha, @codigo_marca, @codigo_colecao, @codigo_espessura, @codigo_grade1, @codigo_grade2, @unidade, @ativo, @codigo_classificacao, @dt_cadastro, @observacao, @cod_fornecedor, @dt_update, @altura_para_frete, @largura_para_frete, @comprimento_para_frete, @timestamp, @peso_bruto, @portal, @descricao_completa_commerce, @canais_ecommerce_publicados, @inicio_publicacao_produto, @fim_publicacao_produto, @codigo_integracao_oms)";

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
