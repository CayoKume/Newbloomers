using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaColecoesCommandHandler : IB2CConsultaColecoesCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaColecoes> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_colecao}'"));
            return $"SELECT CONCAT('[', CODIGO_COLECAO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACOLECOES] WHERE CODIGO_COLECAO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_colecao], [nome_colecao], [timestamp], [marcas], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_colecao, @nome_colecao, @timestamp, @marcas, @portal)";
        }
    }
}
