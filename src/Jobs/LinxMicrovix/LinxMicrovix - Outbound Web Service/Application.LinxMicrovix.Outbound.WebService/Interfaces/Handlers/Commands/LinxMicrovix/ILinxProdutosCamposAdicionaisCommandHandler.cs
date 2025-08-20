using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxProdutosCamposAdicionaisCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<LinxProdutosCamposAdicionais> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
