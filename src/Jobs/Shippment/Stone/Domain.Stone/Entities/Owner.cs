using Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Stone.Entities
{
    public class Owner
    {
        public Guid ownerId { get; set; } = new Guid();
        public string name { get; set; }
        public string document { get; set; }
        public string phoneNumber { get; set; }
        public Guid logisticAccountId { get; set; }

        public Owner() { }

        public Owner(Dtos.Owner owner)
        {
            this.ownerId = CustomConvertersExtensions.ConvertToGuidValidation(owner.id);
            this.name = CustomConvertersExtensions.StringLengthValidation(owner.name, 60);
            this.document = Regex.Replace(owner.document, @"[./-]", "");
            this.phoneNumber = CustomConvertersExtensions.StringLengthValidation(owner.phoneNumber, 20);
            this.logisticAccountId = CustomConvertersExtensions.ConvertToGuidValidation(owner.logisticAccountId);
        }
    }
}
