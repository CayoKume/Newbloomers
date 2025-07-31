using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaCodigoRastreioCommandHandler : IB2CConsultaCodigoRastreioCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaCodigoRastreio> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_rastreio}'"));
            return $"SELECT CONCAT('[', CODIGO_RASTREIO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACODIGORASTREIO] WHERE CODIGO_RASTREIO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_pedido], [documento], [serie], [codigo_rastreio], [sequencia_volume], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_pedido, @documento, @serie, @codigo_rastreio, @sequencia_volume, @timestamp, @portal)";
        }
    }
}
