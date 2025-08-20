using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosCommandHandler : IB2CConsultaProdutosAssociadosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosAssociados> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id}'"));
            return $"SELECT CONCAT('[', ID, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSASSOCIADOS] WHERE ID IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id], [codigoproduto], [codigoproduto_associado], [coeficiente_desconto], [timestamp], [portal], [qtde_item], [item_obrigatorio]) 
                          Values 
                          (@lastupdateon, @id, @codigoproduto, @codigoproduto_associado, @coeficiente_desconto, @timestamp, @portal, @qtde_item, @item_obrigatorio)";
        }
    }
}
