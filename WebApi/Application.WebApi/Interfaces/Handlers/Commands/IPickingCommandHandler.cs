using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Interfaces.Handlers.Commands
{
    public interface IPickingCommandHandler
    {
        string CreateGetShippingCompanysQuery();
        string CreateGetUnpickedOrdersQuery(string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        string CreateGetUnpickedOrderQuery(string cnpj_emp, string serie, string nr_pedido);
        string CreateGetUnpickedOrderToPrintQuery(string cnpj_emp, string serie, string nr_pedido);
        string CreateGetUnpickedOrdersToPrintQuery(string cnpj_emp, string serie_pedido, string data_inicial, string data_final);
        string CreateUpdateRetornoQuery(string nr_pedido, int volumes, string listProdutos);
        string CreateUpdateShippingCompanyQuery(string nr_pedido, int cod_transportador);
    }
}
