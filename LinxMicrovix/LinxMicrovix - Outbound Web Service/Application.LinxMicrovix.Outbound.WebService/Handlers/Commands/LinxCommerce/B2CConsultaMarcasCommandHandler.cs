using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaMarcasCommandHandler : IB2CConsultaMarcasCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaMarcas> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_marca}'"));
            return $"SELECT CONCAT('[', CODIGO_MARCA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAMARCAS] WHERE CODIGO_MARCA IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_marca], [nome_marca], [timestamp], [linhas], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_marca, @nome_marca, @timestamp, @linhas, @portal)";
        }
    }
}
