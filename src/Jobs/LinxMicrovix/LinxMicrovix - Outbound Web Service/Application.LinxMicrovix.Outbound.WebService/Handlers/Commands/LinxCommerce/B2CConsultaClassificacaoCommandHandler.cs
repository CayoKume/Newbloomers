using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaClassificacaoCommandHandler : IB2CConsultaClassificacaoCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaClassificacao> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_classificacao}'"));
            return $"SELECT CONCAT('[', CODIGO_CLASSIFICACAO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLASSIFICACAO] WHERE CODIGO_CLASSIFICACAO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_classificacao], [nome_classificacao], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_classificacao, @nome_classificacao, @timestamp, @portal)";
        }
    }
}
