using Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Entities
{
    public class Address
    {
        public Guid pickupPointId { get; set; }
        public string customerDocument { get; set; }
        public bool partialMatch { get; set; }
        public string referenceKey { get; set; }
        public string chave { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public decimal latitude { get; set; }
        public Guid accountId { get; set; }
        public decimal longitude { get; set; }
        public string complement { get; set; }
        public string countryState { get; set; }
        public string locationType { get; set; }
        public string neighborhood { get; set; }
        public string addressNumber { get; set; }
        public Guid orderId { get; set; }

        public Address() { }

        public Address(Dtos.Deliveryaddress deliveryAddress, string customerDocument, string orderId)
        {
            this.chave = deliveryAddress.key;
            this.city = deliveryAddress.city;
            this.address = deliveryAddress.address;
            this.country = deliveryAddress.country;
            this.zipCode = deliveryAddress.zipCode;
            this.latitude = CustomConvertersExtensions.ConvertToDecimalValidation(deliveryAddress.latitude);
            this.accountId = CustomConvertersExtensions.ConvertToGuidValidation(deliveryAddress.accountId);
            this.longitude = CustomConvertersExtensions.ConvertToDecimalValidation(deliveryAddress.longitude);
            this.complement = deliveryAddress.reference + deliveryAddress.complement;
            this.countryState = deliveryAddress.countryState;
            this.locationType = deliveryAddress.locationType;
            this.neighborhood = deliveryAddress.neighborhood;
            this.addressNumber = deliveryAddress.addressNumber;
            this.customerDocument = customerDocument;
            this.orderId = CustomConvertersExtensions.ConvertToGuidValidation(orderId);
        }

        public Address(Dtos.Pickupaddress pickupAddress, string orderId)
        {
            this.pickupPointId = CustomConvertersExtensions.ConvertToGuidValidation(pickupAddress.id);
            this.chave = pickupAddress.key;
            this.city = pickupAddress.city;
            this.address = pickupAddress.address;
            this.country = pickupAddress.country;
            this.zipCode = pickupAddress.zipCode;
            this.latitude = CustomConvertersExtensions.ConvertToDecimalValidation(pickupAddress.latitude);
            this.accountId = CustomConvertersExtensions.ConvertToGuidValidation(pickupAddress.accountId);
            this.longitude = CustomConvertersExtensions.ConvertToDecimalValidation(pickupAddress.longitude);
            this.complement = pickupAddress.complement;
            this.countryState = pickupAddress.countryState;
            this.locationType = pickupAddress.locationType;
            this.customerDocument = "0";
            this.neighborhood = pickupAddress.neighborhood;
            this.partialMatch = CustomConvertersExtensions.ConvertToBooleanValidation(pickupAddress.partialMatch);
            this.referenceKey = pickupAddress.referenceKey;
            this.addressNumber = pickupAddress.addressNumber;
            this.orderId = CustomConvertersExtensions.ConvertToGuidValidation(orderId);
        }
    }
}
