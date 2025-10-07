using Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Entities
{
    public class Item
    {
        public Guid orderId { get; set; }
        public string code { get; set; }
        public decimal depth { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public decimal quantity { get; set; }
        public decimal unitPrice { get; set; }
        public string invoiceKey { get; set; }
        public string description { get; set; }
        public string invoiceNumber { get; set; }
        public decimal invoiceTotalValue { get; set; }

        public Item() { }

        public Item(Dtos.Item item, string orderId)
        {
            this.orderId = CustomConvertersExtensions.ConvertToGuidValidation(orderId);
            this.code = CustomConvertersExtensions.StringLengthValidation(item.code, 50);
            this.depth = CustomConvertersExtensions.ConvertToDecimalValidation(item.depth);
            this.width = CustomConvertersExtensions.ConvertToDecimalValidation(item.width);
            this.height = CustomConvertersExtensions.ConvertToDecimalValidation(item.height);
            this.weight = CustomConvertersExtensions.ConvertToDecimalValidation(item.weight);
            this.quantity = CustomConvertersExtensions.ConvertToDecimalValidation(item.quantity);
            this.unitPrice = CustomConvertersExtensions.ConvertToDecimalValidation(item.unitPrice);
            this.invoiceKey = CustomConvertersExtensions.StringLengthValidation(item.invoiceKey, 44);
            this.description = CustomConvertersExtensions.StringLengthValidation(item.description, 255);
            this.invoiceNumber = CustomConvertersExtensions.StringLengthValidation(item.invoiceNumber, 50);
            this.invoiceTotalValue = CustomConvertersExtensions.ConvertToDecimalValidation(item.invoiceTotalValue);
        }
    }
}
