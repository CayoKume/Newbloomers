using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface IExecuteCancellationCommandHandler
    {
        string CreateGetReasonsQuery();
        string CreateGetOrdersToCancelQuery(string serie, string doc_company);
        string CreateUpdateDateCanceledQuery(string number, string suporte, string inputObs, int motivo);
    }
}
