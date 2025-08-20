using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaVendedoresCommandHandler : IB2CConsultaVendedoresCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaVendedores> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.cod_vendedor}'"));
            return $"SELECT CONCAT('[', COD_VENDEDOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAVENDEDORES] WHERE COD_VENDEDOR IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}]
                          ([lastupdateon], [cod_vendedor], [nome_vendedor], [comissao_produtos], [comissao_servicos], [tipo], [ativo], [comissionado], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @cod_vendedor, @nome_vendedor, @comissao_produtos, @comissao_servicos, @tipo, @ativo, @comissionado, @timestamp, @portal)";
        }
    }
}
