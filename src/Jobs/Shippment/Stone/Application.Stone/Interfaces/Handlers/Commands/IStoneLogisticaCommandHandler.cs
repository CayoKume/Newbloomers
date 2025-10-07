using Domain.Stone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Stone.Interfaces.Handlers.Commands
{
    public interface IStoneLogisticaCommandHandler
    {
        string CreateGetParametersQuery();
        string CreateGetExistingReferenceKeysQuery();
        string CreateGetRegistersExistsQuery();
        string CreateGetRegistersExistsQuery(List<Guid> registros);

        string CreateInsertZplsQuery(List<Zpl> zpls);
        string CreateInsertRecordQuery(string tableName);
    }
}
