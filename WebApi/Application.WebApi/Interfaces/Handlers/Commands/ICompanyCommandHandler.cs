using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface ICompanyCommandHandler
    {
        string CreateGetCompanysQuery();
        string CreateGetUsersQuery();
    }
}
