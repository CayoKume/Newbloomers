using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Entities
{
    public class Customer
    {
        public string name { get; set; }
        public string email { get; set; }
        public string document { get; set; } = "0";
        public string phoneNumber { get; set; }

        public Customer() { }

        public Customer(Dtos.Customer customer)
        {
            this.name = customer.name;
            this.email = customer.email;
            this.document = customer.document;
            this.phoneNumber = customer.phoneNumber;
        }
    }
}
