using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCommandHandler : IB2CConsultaProdutosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigoproduto}'"));
            return $"SELECT CONCAT('[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOS] WHERE CODIGOPRODUTO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigoproduto], [referencia], [codauxiliar1], [descricao_basica], [nome_produto], [peso_liquido], [codigo_setor], [codigo_linha], [codigo_marca], [codigo_colecao], [codigo_espessura], [codigo_grade1], [codigo_grade2], [unidade], [ativo], [codigo_classificacao], [dt_cadastro], [observacao], [cod_fornecedor], [dt_update], [altura_para_frete], [largura_para_frete], [comprimento_para_frete], [timestamp], [peso_bruto], [portal], [descricao_completa_commerce], [canais_ecommerce_publicados], [inicio_publicacao_produto], [fim_publicacao_produto], [codigo_integracao_oms]) 
                          Values 
                          (@lastupdateon, @codigoproduto, @referencia, @codauxiliar1, @descricao_basica, @nome_produto, @peso_liquido, @codigo_setor, @codigo_linha, @codigo_marca, @codigo_colecao, @codigo_espessura, @codigo_grade1, @codigo_grade2, @unidade, @ativo, @codigo_classificacao, @dt_cadastro, @observacao, @cod_fornecedor, @dt_update, @altura_para_frete, @largura_para_frete, @comprimento_para_frete, @timestamp, @peso_bruto, @portal, @descricao_completa_commerce, @canais_ecommerce_publicados, @inicio_publicacao_produto, @fim_publicacao_produto, @codigo_integracao_oms)";
        }
    }
}
