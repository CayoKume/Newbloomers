using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPlanosCommandHandler : IB2CConsultaPlanosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaPlanos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.plano}'"));
            return $"SELECT CONCAT('[', PLANO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPLANOS] WHERE PLANO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [plano], [nome_plano], [forma_pagamento], [qtde_parcelas], [valor_minimo_parcela], [indice], [timestamp], [desativado], [tipo_plano], [portal]) 
                          Values 
                          (@lastupdateon, @plano, @nome_plano, @forma_pagamento, @qtde_parcelas, @valor_minimo_parcela, @indice, @timestamp, @desativado, @tipo_plano, @portal)";
        }
    }
}
