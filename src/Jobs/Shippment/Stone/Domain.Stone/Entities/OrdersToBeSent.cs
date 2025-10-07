using Domain.Core.Entities.Base;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Stone.Entities
{
    public class OrdersToBeSent : OrderBase
    {
        private List<Product> _itens = new List<Product>();

        public Client? client { get; set; }
        public Company? company { get; set; }
        public ShippingCompany? shippingCompany { get; set; }
        public Invoice? invoice { get; set; }
        public List<Product> itens { get { return _itens; } set { _itens = value; } }
    }
}
