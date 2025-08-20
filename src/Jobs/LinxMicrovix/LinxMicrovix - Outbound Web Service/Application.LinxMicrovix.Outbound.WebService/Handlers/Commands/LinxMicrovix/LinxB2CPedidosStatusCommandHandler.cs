using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class LinxB2CPedidosStatusCommandHandler : ILinxB2CPedidosStatusCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<int?> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r}'"));
            return $"SELECT CONCAT('[', ID, ']', '|', '[', ID_STATUS, ']', '|', '[', ID_PEDIDO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CPedidosStatus] WHERE id IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}]
                            ([lastupdateon],[id],[id_status],[id_pedido],[data_hora],[anotacao],[timestamp],[portal])
                            Values
                            (@lastupdateon,@id,@id_status,@id_pedido,@data_hora,@anotacao,@timestamp,@portal)";
        }
    }
}
