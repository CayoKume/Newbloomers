using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaImagensHDCommandHandler : IB2CConsultaImagensHDCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaImagensHD> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigoproduto}'"));
            return $"SELECT CONCAT('[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAIMAGENSHD] WHERE CODIGOPRODUTO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [portal], [identificador_imagem], [codigoproduto], [timestamp], [url_imagem_blob]) 
                          Values 
                          (@lastupdateon, @portal, @identificador_imagem, @codigoproduto, @timestamp, @url_imagem_blob)";
        }
    }
}
