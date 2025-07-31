using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface IAttendanceCommandHandler
    {
        string CreateGetOrdersToContactQuery(string serie, string doc_company);
        string CreateUpdateDateContactedQuery(string number, string atendente, string obs);
    }
}
