using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosTabelasCommandHandler : IB2CConsultaProdutosTabelasCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosTabelas> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_tabela}'"));
            return $"SELECT CONCAT('[', ID_TABELA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSTABELAS] WHERE ID_TABELA IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_tabela], [nome_tabela], [ativa], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_tabela, @nome_tabela, @ativa, @timestamp, @portal)";
        }
    }
}
