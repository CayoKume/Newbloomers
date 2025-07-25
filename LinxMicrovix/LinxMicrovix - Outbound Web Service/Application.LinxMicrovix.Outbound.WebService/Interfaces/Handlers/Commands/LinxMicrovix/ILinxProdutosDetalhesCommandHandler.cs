using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxProdutosDetalhesCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<LinxProdutosDetalhes> registros);
        string CreateGetPendingRegistersQuery();
        string CreateInsertRecordQuery(string tableName);
    }
}
