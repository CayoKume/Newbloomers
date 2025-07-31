using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface IHomeCommandHandler
    {
        string CreateGetPickupOrdersQuery(string doc_company);
    }
}
