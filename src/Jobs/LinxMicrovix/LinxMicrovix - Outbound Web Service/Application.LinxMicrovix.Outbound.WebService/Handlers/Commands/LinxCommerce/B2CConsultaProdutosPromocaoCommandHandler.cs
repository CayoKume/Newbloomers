using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoCommandHandler : IB2CConsultaProdutosPromocaoCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosPromocao> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigoproduto}'"));
            return $"SELECT CONCAT('[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSPROMOCAO] WHERE CODIGOPRODUTO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_promocao], [empresa], [codigoproduto], [preco], [data_inicio], [data_termino], [data_cadastro], [ativa], [codigo_campanha], [promocao_opcional], [timestamp], [referencia], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_promocao, @empresa, @codigoproduto, @preco, @data_inicio, @data_termino, @data_cadastro, @ativa, @codigo_campanha, @promocao_opcional, @timestamp, @referencia, @portal)";
        }
    }
}
