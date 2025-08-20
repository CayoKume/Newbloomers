using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCodebarCommandHandler : IB2CConsultaProdutosCodebarCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCodebar> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigoproduto}'"));
            return $"SELECT CONCAT('[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCODEBAR] WHERE CODIGOPRODUTO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigoproduto], [codebar], [id_produtos_codebar], [principal], [empresa], [timestamp], [tipo_codebar], [portal]) 
                          Values 
                          (@lastupdateon, @codigoproduto, @codebar, @id_produtos_codebar, @principal, @empresa, @timestamp, @tipo_codebar, @portal)";
        }
    }
}
