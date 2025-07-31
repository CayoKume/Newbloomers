using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface ILabelsCommandHandler
    {
        string CreateGetOrdersToPresentQuery(string cnpj_emp, string serie, string nr_pedido);
        string CreateGetOrdersToPrintQuery(string cnpj_emp, string serie, string data_inicial, string data_final);
        string CreateGetOrderToPrintQuery(string cnpj_emp, string serie, string nr_pedido);
        string CreateUpdatePrintedFlagQuery(string nr_pedido);
    }
}
