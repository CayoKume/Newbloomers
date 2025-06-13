using Domain.IntegrationsCore.Models.Bases;

namespace Domain.Jadlog.Entities
{
    public class Order : OrderBase
    {
        private List<Product> _itens = new List<Product>();

        public string TIPO_SERVICO { get; set; }
        public CompanyBase tomador { get; set; }

        public List<Product> itens { get { return _itens; } set { _itens = value; } }
    }
}
