using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosDepositosCommandHandler : IB2CConsultaProdutosDepositosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosDepositos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_deposito}'"));
            return $"SELECT CONCAT('[', ID_DEPOSITO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSDEPOSITOS] WHERE ID_DEPOSITO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_deposito], [nome_deposito], [disponivel], [disponivel_transferencia], [disponivel_franquias], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_deposito, @nome_deposito, @disponivel, @disponivel_transferencia, @disponivel_franquias, @timestamp, @portal)";
        }
    }
}
