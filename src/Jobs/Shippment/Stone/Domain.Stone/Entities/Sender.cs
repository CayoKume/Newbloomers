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
            this.name = sender.name;
            this.email = sender.email;
            this.document = sender.document;
            this.phoneNumber = sender.phoneNumber;
            this.logisticAccountId = CustomConvertersExtensions.ConvertToGuidValidation(sender.logisticAccountId);
        }
    }
}
