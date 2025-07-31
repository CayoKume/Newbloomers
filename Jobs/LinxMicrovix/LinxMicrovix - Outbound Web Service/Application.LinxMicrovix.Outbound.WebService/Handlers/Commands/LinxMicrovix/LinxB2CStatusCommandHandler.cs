using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class LinxB2CStatusCommandHandler : ILinxB2CStatusCommandHandler
    {
        public string CreateGetRegistersExistsQuery()
        {
            return "SELECT CONCAT('[', ID_STATUS, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CStatus]";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}]
                            ([lastupdateon],[id_status],[descricao_status],[timestamp],[portal])
                            Values
                            (@lastupdateon,@id_status,@descricao_status,@timestamp,@portal)";
        }
    }
}
