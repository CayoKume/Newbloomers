using Domain.Core.Extensions;
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
            this.name = CustomConvertersExtensions.StringLengthValidation(customer.name, 60);
            this.email = CustomConvertersExtensions.StringLengthValidation(customer.email, 50);
            this.document = CustomConvertersExtensions.StringLengthValidation(customer.document, 14);
            this.phoneNumber = CustomConvertersExtensions.StringLengthValidation(customer.phoneNumber, 20);
        }
    }
}
