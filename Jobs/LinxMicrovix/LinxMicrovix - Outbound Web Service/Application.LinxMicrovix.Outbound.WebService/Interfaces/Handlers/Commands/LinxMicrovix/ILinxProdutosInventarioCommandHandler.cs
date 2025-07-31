using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxProdutosInventarioCommandHandler
    {
        string CreateGetProductsDepositsIdsQuery();
        string CreateGetRegistersExistsQuery(List<LinxProdutosInventario> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
