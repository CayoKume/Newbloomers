using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomesCommandHandler : IB2CConsultaProdutosCamposAdicionaisNomesCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCamposAdicionaisNomes> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_campo}'"));
            return $"SELECT CONCAT('[', ID_CAMPO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCAMPOSADICIONAISNOMES] WHERE ID_CAMPO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_campo], [ordem], [legenda], [tipo], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_campo, @ordem, @legenda, @tipo, @timestamp, @portal)";
        }
    }
}
