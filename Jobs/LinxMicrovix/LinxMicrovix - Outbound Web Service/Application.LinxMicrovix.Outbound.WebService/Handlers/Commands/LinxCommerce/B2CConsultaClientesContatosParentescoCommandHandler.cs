using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaClientesContatosParentescoCommandHandler : IB2CConsultaClientesContatosParentescoCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaClientesContatosParentesco> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_parentesco}'"));
            return $"SELECT CONCAT('[', ID_PARENTESCO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESCONTATOSPARENTESCO] WHERE ID_PARENTESCO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_parentesco], [descricao_parentesco], [timestamp], [portal])
                          Values 
                          (@lastupdateon, @id_parentesco, @descricao_parentesco, @timestamp, @portal)";
        }
    }
}
