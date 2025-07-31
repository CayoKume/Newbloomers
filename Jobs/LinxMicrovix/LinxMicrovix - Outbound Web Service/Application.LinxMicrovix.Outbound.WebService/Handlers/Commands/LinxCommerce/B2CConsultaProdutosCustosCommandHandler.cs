using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCustosCommandHandler : IB2CConsultaProdutosCustosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCustos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_produtos_custos}'"));
            return $"SELECT CONCAT('[', ID_PRODUTOS_CUSTOS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCUSTOS] WHERE ID_PRODUTOS_CUSTOS IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_produtos_custos], [codigoproduto], [empresa], [custoicms1], [ipi1], [markup], [customedio], [frete1], [precisao], [precominimo], [dt_update], [custoliquido], [precovenda], [custototal], [precocompra], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_produtos_custos, @codigoproduto, @empresa, @custoicms1, @ipi1, @markup, @customedio, @frete1, @precisao, @precominimo, @dt_update, @custoliquido, @precovenda, @custototal, @precocompra, @timestamp, @portal)";
        }
    }
}
