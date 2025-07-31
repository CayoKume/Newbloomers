using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesCommandHandler : IB2CConsultaProdutosInformacoesCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosInformacoes> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_produtos_informacoes}'"));
            return $"SELECT CONCAT('[', ID_PRODUTOS_INFORMACOES, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTES] WHERE ID_PRODUTOS_INFORMACOES IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_produtos_informacoes], [codigoproduto], [informacoes_produto], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_produtos_informacoes, @codigoproduto, @informacoes_produto, @timestamp, @portal)";
        }
    }
}
