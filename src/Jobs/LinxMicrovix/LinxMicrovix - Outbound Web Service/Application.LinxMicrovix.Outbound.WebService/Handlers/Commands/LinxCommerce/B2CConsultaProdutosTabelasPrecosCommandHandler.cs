using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecosCommandHandler : IB2CConsultaProdutosTabelasPrecosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosTabelasPrecos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_prod_tab_preco}'"));
            return $"SELECT CONCAT('[', ID_PROD_TAB_PRECO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CConsultaProdutosTabelasPrecos] WHERE ID_PROD_TAB_PRECO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_prod_tab_preco], [id_tabela], [codigoproduto], [precovenda], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_prod_tab_preco, @id_tabela, @codigoproduto, @precovenda, @timestamp, @portal)";
        }
    }
}
