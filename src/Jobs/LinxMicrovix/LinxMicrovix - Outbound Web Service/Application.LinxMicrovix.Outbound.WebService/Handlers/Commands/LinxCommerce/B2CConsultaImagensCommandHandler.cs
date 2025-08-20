using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaImagensCommandHandler : IB2CConsultaImagensCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaImagens> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_imagem}'"));
            return $"SELECT CONCAT('[', ID_IMAGEM, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAIMAGENS] WHERE ID_IMAGEM IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_imagem], [md5], [timestamp], [portal], [url_imagem_blob]) 
                          Values 
                          (@lastupdateon, @id_imagem, @md5, @timestamp, @portal, @url_imagem_blob)";
        }
    }
}
