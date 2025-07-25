using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaLinhasCommandHandler : IB2CConsultaLinhasCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaLinhas> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_linha}'"));
            return $"SELECT CONCAT('[', CODIGO_LINHA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTALINHAS] WHERE CODIGO_LINHA IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_linha], [nome_linha], [timestamp], [setores], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_linha, @nome_linha, @timestamp, @setores, @portal)";
        }
    }
}
