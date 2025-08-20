using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaSetoresCommandHandler : IB2CConsultaSetoresCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaSetores> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_setor}'"));
            return $"SELECT CONCAT('[', CODIGO_SETOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTASETORES] WHERE CODIGO_SETOR IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_setor], [nome_setor], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_setor, @nome_setor, @timestamp, @portal)";
        }
    }
}
