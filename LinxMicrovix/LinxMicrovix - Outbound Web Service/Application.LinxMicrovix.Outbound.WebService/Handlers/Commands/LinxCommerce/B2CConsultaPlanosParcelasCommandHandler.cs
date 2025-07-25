using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPlanosParcelasCommandHandler : IB2CConsultaPlanosParcelasCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaPlanosParcelas> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_planos_parcelas}'"));
            return $"SELECT CONCAT('[', ID_PLANOS_PARCELAS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTES] WHERE ID_PLANOS_PARCELAS IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [plano], [ordem_parcela], [prazo_parc], [id_planos_parcelas], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @plano, @ordem_parcela, @prazo_parc, @id_planos_parcelas, @timestamp, @portal)";
        }
    }
}
