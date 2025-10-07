using Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Entities
{
    public class Sender
    {
        public string name { get; set; }
        public string email { get; set; }
        public string document { get; set; } = "0";
        public string phoneNumber { get; set; }
        public Guid logisticAccountId { get; set; }

        public Sender() { }

        public Sender(Dtos.Sender sender)
        {
            this.name = CustomConvertersExtensions.StringLengthValidation(sender.name, 60);
            this.email = CustomConvertersExtensions.StringLengthValidation(sender.email, 50);
            this.document = CustomConvertersExtensions.StringLengthValidation(sender.document, 14);
            this.phoneNumber = CustomConvertersExtensions.StringLengthValidation(sender.phoneNumber, 20);
            this.logisticAccountId = CustomConvertersExtensions.ConvertToGuidValidation(sender.logisticAccountId);
        }
    }
}
