using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositosCommandHandler : IB2CConsultaProdutosDetalhesDepositosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosDetalhesDepositos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.deposito}'"));
            return $"SELECT CONCAT('[', DEPOSITO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSDETALHESDEPOSITOS] WHERE DEPOSITO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [codigoproduto], [empresa], [id_deposito], [saldo], [timestamp], [portal], [deposito], [tempo_preparacao_estoque]) 
                          Values 
                          (@lastupdateon, @codigoproduto, @empresa, @id_deposito, @saldo, @timestamp, @portal, @deposito, @tempo_preparacao_estoque)";
        }
    }
}
