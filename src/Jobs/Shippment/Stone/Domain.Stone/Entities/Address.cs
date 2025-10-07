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
            this.chave = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.key, 800);
            this.city = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.city, 40);
            this.address = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.address, 250);
            this.country = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.country, 60);
            this.zipCode = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.zipCode, 9);
            this.latitude = CustomConvertersExtensions.ConvertToDecimalValidation(deliveryAddress.latitude);
            this.accountId = CustomConvertersExtensions.ConvertToGuidValidation(deliveryAddress.accountId);
            this.longitude = CustomConvertersExtensions.ConvertToDecimalValidation(deliveryAddress.longitude);
            this.complement = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.reference + deliveryAddress.complement, 300);
            this.countryState = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.countryState, 2);
            this.locationType = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.locationType, 60);
            this.neighborhood = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.neighborhood, 60);
            this.addressNumber = CustomConvertersExtensions.StringLengthValidation(deliveryAddress.addressNumber, 20);
            this.customerDocument = CustomConvertersExtensions.StringLengthValidation(customerDocument, 14);
            this.orderId = CustomConvertersExtensions.ConvertToGuidValidation(orderId);
        }

        public Address(Dtos.Pickupaddress pickupAddress, string orderId)
        {
            this.pickupPointId = CustomConvertersExtensions.ConvertToGuidValidation(pickupAddress.id);
            this.chave = CustomConvertersExtensions.StringLengthValidation(pickupAddress.key, 800);
            this.city = CustomConvertersExtensions.StringLengthValidation(pickupAddress.city, 40);
            this.address = CustomConvertersExtensions.StringLengthValidation(pickupAddress.address, 250);
            this.country = CustomConvertersExtensions.StringLengthValidation(pickupAddress.country, 60);
            this.zipCode = CustomConvertersExtensions.StringLengthValidation(pickupAddress.zipCode, 9);
            this.latitude = CustomConvertersExtensions.ConvertToDecimalValidation(pickupAddress.latitude);
            this.accountId = CustomConvertersExtensions.ConvertToGuidValidation(pickupAddress.accountId);
            this.longitude = CustomConvertersExtensions.ConvertToDecimalValidation(pickupAddress.longitude);
            this.complement = CustomConvertersExtensions.StringLengthValidation(pickupAddress.complement, 300);
            this.countryState = CustomConvertersExtensions.StringLengthValidation(pickupAddress.countryState, 2);
            this.locationType = CustomConvertersExtensions.StringLengthValidation(pickupAddress.locationType, 60);
            this.customerDocument = "0";
            this.neighborhood = CustomConvertersExtensions.StringLengthValidation(pickupAddress.neighborhood, 60);
            this.partialMatch = CustomConvertersExtensions.ConvertToBooleanValidation(pickupAddress.partialMatch);
            this.referenceKey = CustomConvertersExtensions.StringLengthValidation(pickupAddress.referenceKey, 300);
            this.addressNumber = CustomConvertersExtensions.StringLengthValidation(pickupAddress.addressNumber, 20);
            this.orderId = CustomConvertersExtensions.ConvertToGuidValidation(orderId);
        }
    }
}
