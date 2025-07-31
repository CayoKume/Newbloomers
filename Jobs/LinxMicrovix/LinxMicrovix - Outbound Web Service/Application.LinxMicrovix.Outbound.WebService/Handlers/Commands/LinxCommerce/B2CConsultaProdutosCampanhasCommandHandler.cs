using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasCommandHandler : IB2CConsultaProdutosCampanhasCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCampanhas> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_campanha}'"));
            return $"SELECT CONCAT('[', CODIGO_CAMPANHA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCAMPANHAS] WHERE CODIGO_CAMPANHA IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigo_campanha], [nome_campanha], [vigencia_inicio], [vigencia_fim], [observacao], [ativo], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @codigo_campanha, @nome_campanha, @vigencia_inicio, @vigencia_fim, @observacao, @ativo, @timestamp, @portal)";
        }
    }
}
