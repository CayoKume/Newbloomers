using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaEspessurasCommandHandler : IB2CConsultaEspessurasCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaEspessuras> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_espessura}'"));
            return $"SELECT CONCAT('[', CODIGO_ESPESSURA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAESPESSURAS] WHERE CODIGO_ESPESSURA IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_espessura], [nome_espessura], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_espessura, @nome_espessura, @timestamp, @portal)";
        }
    }
}
