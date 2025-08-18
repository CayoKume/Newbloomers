using Domain.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface ICancellationRequestCommandHandler
    {
        string CreateCancellationRequestQuery(CancellationRequestOrder order);
        string CreateGetOrderToCancelQuery(string number, string serie, string doc_company);
        string CreateGetReasonsQuery();
    }
}
