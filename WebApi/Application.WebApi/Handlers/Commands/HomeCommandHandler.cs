using Application.WebApi.Interfaces.Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Handlers.Commands
{
    public class HomeCommandHandler : IHomeCommandHandler
    {
        public string CreateGetPickupOrdersQuery(string doc_company)
        {
            return $@"SELECT DOCUMENTO AS NUMBER, DATA AS DATA_PEDIDO FROM GENERAL..IT4_WMS_DOCUMENTO (NOLOCK) WHERE (NB_TRANSPORTADORA = 65281 OR NB_TRANSPORTADORA = 97586) AND NB_DOC_REMETENTE = {doc_company} AND CHAVE_NFE IS NULL AND CANCELADO IS NULL AND CANCELAMENTO IS NULL AND DATA > '2024-06-01'";
        }
    }
}
