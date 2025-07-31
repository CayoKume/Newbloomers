using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosImagensCommandHandler : IB2CConsultaProdutosImagensCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosImagens> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_imagem}'"));
            return $"SELECT CONCAT('[', ID_IMAGEM, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSIMAGENS] WHERE ID_IMAGEM IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_imagem_produto], [id_imagem], [codigoproduto], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_imagem_produto, @id_imagem, @codigoproduto, @timestamp, @portal)";
        }
    }
}
