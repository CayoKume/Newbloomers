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
        string CreateGetRegistersExistsQuery();

        string CreateInsertRecordQuery(string tableName);
    }
}
