using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.Stone.Entities
{
    public class Order
    {
        public Guid orderId { get; set; } = new Guid();
        public Guid quoteId { get; set; } = new Guid();
        public Guid senderAccountId { get; set; } = new Guid();
        public Guid ownerAccountId { get; set; } = new Guid();
        public Guid pickupPointId { get; set; } = new Guid();
        public Guid updateId { get; set; } = new Guid();
        public Guid trackingStreamCode { get; set; } = new Guid();

        public DateTime createdAt { get; set; } = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        public DateTime updatedAt { get; set; } = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        public DateTime customerDeadlineDate { get; set; } = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        public DateTime deadlineDate { get; set; } = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        public DateTime deliveredAt { get; set; } = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        public DateTime collectedAt { get; set; } = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

        public string orderNumber { get; set; }
        public string pickupType { get; set; }
        public string referenceKey { get; set; }
        public string status { get; set; }
        public string carrierReferenceKey { get; set; }
        public string trackingCode { get; set; }
        public string tagUrl { get; set; }
        public string quoteExpirationDate { get; set; }
        public string statusReason { get; set; }
        public string modifiedBy { get; set; }
        public string customerName { get; set; }
        public string customerDocument { get; set; }
        public string senderName { get; set; }
        public string senderDocument { get; set; }
        public string carrierName { get; set; }
        public string carrierService { get; set; }

        public bool isFromIntegration { get; set; }
        public bool isUsingContractPrice { get; set; }
        public bool shouldForceTracking { get; set; }
        public bool acceptedAgreements { get; set; }
        public bool userCanCancelDelivery { get; set; }
        public bool wasTagGenerated { get; set; }
        public bool insurance { get; set; }

        public decimal contractPrice { get; set; }
        public decimal totalCost { get; set; }
        public decimal discount { get; set; }
        public decimal totalDepth { get; set; }
        public decimal totalSizes { get; set; }
        public decimal totalWidth { get; set; }
        public decimal totalCubage { get; set; }
        public decimal totalHeight { get; set; }
        public decimal totalWeight { get; set; }

        public Int32 retryTimes { get; set; }
        public Int32 slaWorkingDays { get; set; }

        public Int64 totalETA { get; set; }
        
        [SkipProperty]
        public Customer customer { get; set; } = new Customer();

        [SkipProperty]
        public Sender sender { get; set; } = new Sender();

        [SkipProperty]
        public List<Address> addresses { get; set; } = new List<Address>();
        
        [SkipProperty]
        public List<Item> items { get; set; } = new List<Item>();
        
        [SkipProperty]
        public List<Event> events { get; set; } = new List<Event>();
        
        [SkipProperty]
        public Owner owner { get; set; } = new Owner();

        [SkipProperty]
        public Error error { get; set; } = new Error();

        [NotMapped]
        [SkipProperty]
        public Dictionary<string, string> Responses { get; set; } = new Dictionary<string, string>();

        public Order() { }

        public Order(Dtos.Order order)
        {
            //if (!order.metrics.totalSizes.Contains(".") && order.metrics?.totalSizes.Length > 9)
            //{
            //    var teste = order.metrics?.totalSizes.Insert((int)order.metrics?.totalSizes.Length - 2, "."); 
            //}

            orderId = CustomConvertersExtensions.ConvertToGuidValidation(order.id);
            quoteId = CustomConvertersExtensions.ConvertToGuidValidation(order.quoteId);
            senderAccountId = CustomConvertersExtensions.ConvertToGuidValidation(order.senderAccountId);
            ownerAccountId = CustomConvertersExtensions.ConvertToGuidValidation(order.ownerAccountId);
            pickupPointId = CustomConvertersExtensions.ConvertToGuidValidation(order.pickupPointId);
            updateId = CustomConvertersExtensions.ConvertToGuidValidation(order.updateId);
            trackingStreamCode = CustomConvertersExtensions.ConvertToGuidValidation(order.trackingStreamCode);

            createdAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.createdAt);
            updatedAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.updatedAt);
            customerDeadlineDate = CustomConvertersExtensions.ConvertToDateTimeValidation(order.customerDeadlineDate);
            deadlineDate = CustomConvertersExtensions.ConvertToDateTimeValidation(order.deadlineDate);
            deliveredAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.deliveredAt);
            collectedAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.collectedAt);

            this.orderNumber = CustomConvertersExtensions.StringLengthValidation(order.referenceKey, 20).Replace("3294_29_", "");
            pickupType = CustomConvertersExtensions.StringLengthValidation(order.pickupType, 60);
            referenceKey = CustomConvertersExtensions.StringLengthValidation(order.referenceKey, 50);
            status = CustomConvertersExtensions.StringLengthValidation(order.status, 50);
            carrierReferenceKey = CustomConvertersExtensions.StringLengthValidation(order.carrierReferenceKey, 50);
            trackingCode = CustomConvertersExtensions.StringLengthValidation(order.trackingCode, 50);
            tagUrl = CustomConvertersExtensions.StringLengthValidation(order.tagUrl, 300);
            quoteExpirationDate = CustomConvertersExtensions.StringLengthValidation(order.quoteExpirationDate, 50);
            statusReason = CustomConvertersExtensions.StringLengthValidation(order.statusReason, 300);
            modifiedBy = CustomConvertersExtensions.StringLengthValidation(order.modifiedBy, 50);
            customerName = CustomConvertersExtensions.StringLengthValidation(order.customer?.name, 60);
            customerDocument = CustomConvertersExtensions.StringLengthValidation(order.customer?.document, 14);
            senderName = CustomConvertersExtensions.StringLengthValidation(order.sender?.name, 60);
            senderDocument = CustomConvertersExtensions.StringLengthValidation(order.sender?.document, 14);
            carrierName = CustomConvertersExtensions.StringLengthValidation(order.carrier?.name, 60);
            carrierService = CustomConvertersExtensions.StringLengthValidation(order.carrier?.service, 60);

            isFromIntegration = CustomConvertersExtensions.ConvertToBooleanValidation(order.isFromIntegration);
            isUsingContractPrice = CustomConvertersExtensions.ConvertToBooleanValidation(order.isUsingContractPrice);
            shouldForceTracking = CustomConvertersExtensions.ConvertToBooleanValidation(order.shouldForceTracking);
            acceptedAgreements = CustomConvertersExtensions.ConvertToBooleanValidation(order.acceptedAgreements);
            userCanCancelDelivery = CustomConvertersExtensions.ConvertToBooleanValidation(order.userCanCancelDelivery);
            wasTagGenerated = CustomConvertersExtensions.ConvertToBooleanValidation(order.wasTagGenerated);
            insurance = CustomConvertersExtensions.ConvertToBooleanValidation(order.insurance);

            contractPrice = CustomConvertersExtensions.ConvertToDecimalValidation(order.contractPrice);
            totalCost = CustomConvertersExtensions.ConvertToDecimalValidation(order.totalCost);
            discount = CustomConvertersExtensions.ConvertToDecimalValidation(order.discount);
            totalDepth = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalDepth);
            totalSizes = CustomConvertersExtensions.ConvertToDecimalValidation(!order.metrics.totalSizes.Contains(".") && order.metrics?.totalSizes.Length > 9 ? order.metrics?.totalSizes.Insert((int)order.metrics?.totalSizes.Length - 2, ".") : order.metrics?.totalSizes);
            totalWidth = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalWidth);
            totalHeight = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalHeight);
            totalWeight = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalWeight);
            totalCubage = 0;

            retryTimes = CustomConvertersExtensions.ConvertToInt32Validation(order.retryTimes);
            slaWorkingDays = CustomConvertersExtensions.ConvertToInt32Validation(order.slaWorkingDays);

            totalETA = CustomConvertersExtensions.ConvertToInt64Validation(order.totalETA);

            customer = order.customer != null ? new Customer(order.customer) : new Customer();
            sender = order.sender != null ? new Sender(order.sender) : new Sender();
            owner = order.owner != null ? new Owner(order.owner) : new Owner();
            error = String.IsNullOrEmpty(order.message) && String.IsNullOrEmpty(order.error) ? new Error() : new Error(order.referenceKey.Replace("3294_29_", ""), order.message, order.error);

            addresses.Add(order.pickupAddress != null ? new Address(order.pickupAddress, order.id) : new Address());
            addresses.Add(order.deliveryAddress != null ? new Address(order.deliveryAddress, order.customer.document, order.id) : new Address());

            order.events?.ForEach(@event =>
            {
                events.Add(new Event(@event, order.id));
            });

            order.items?.ForEach(item =>
            {
                items.Add(new Item(item, order.id));
            });
        }

        public Order(Dtos.Order order, string response, string orderNumber)
        {
            orderId = CustomConvertersExtensions.ConvertToGuidValidation(order.id);
            quoteId = CustomConvertersExtensions.ConvertToGuidValidation(order.quoteId);
            senderAccountId = CustomConvertersExtensions.ConvertToGuidValidation(order.senderAccountId);
            ownerAccountId = CustomConvertersExtensions.ConvertToGuidValidation(order.ownerAccountId);
            pickupPointId = CustomConvertersExtensions.ConvertToGuidValidation(order.pickupPointId);
            updateId = CustomConvertersExtensions.ConvertToGuidValidation(order.updateId);
            trackingStreamCode = CustomConvertersExtensions.ConvertToGuidValidation(order.trackingStreamCode);

            createdAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.createdAt);
            updatedAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.updatedAt);
            customerDeadlineDate = CustomConvertersExtensions.ConvertToDateTimeValidation(order.customerDeadlineDate);
            deadlineDate = CustomConvertersExtensions.ConvertToDateTimeValidation(order.deadlineDate);
            deliveredAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.deliveredAt);
            collectedAt = CustomConvertersExtensions.ConvertToDateTimeValidation(order.collectedAt);

            this.orderNumber = orderNumber;
            pickupType = order.pickupType;
            referenceKey = order.referenceKey;
            status = order.status;
            carrierReferenceKey = order.carrierReferenceKey;
            trackingCode = order.trackingCode;
            tagUrl = order.tagUrl;
            quoteExpirationDate = order.quoteExpirationDate;
            statusReason = order.statusReason;
            modifiedBy = order.modifiedBy;
            customerName = order.customer?.name;
            customerDocument = order.customer?.document;
            senderName = order.sender?.name;
            senderDocument = order.sender?.document;
            carrierName = order.carrier?.name;
            carrierService = order.carrier?.service;

            isFromIntegration = CustomConvertersExtensions.ConvertToBooleanValidation(order.isFromIntegration);
            isUsingContractPrice = CustomConvertersExtensions.ConvertToBooleanValidation(order.isUsingContractPrice);
            shouldForceTracking = CustomConvertersExtensions.ConvertToBooleanValidation(order.shouldForceTracking);
            acceptedAgreements = CustomConvertersExtensions.ConvertToBooleanValidation(order.acceptedAgreements);
            userCanCancelDelivery = CustomConvertersExtensions.ConvertToBooleanValidation(order.userCanCancelDelivery);
            wasTagGenerated = CustomConvertersExtensions.ConvertToBooleanValidation(order.wasTagGenerated);
            insurance = CustomConvertersExtensions.ConvertToBooleanValidation(order.insurance);

            contractPrice = CustomConvertersExtensions.ConvertToDecimalValidation(order.contractPrice);
            totalCost = CustomConvertersExtensions.ConvertToDecimalValidation(order.totalCost);
            discount = CustomConvertersExtensions.ConvertToDecimalValidation(order.discount);
            totalDepth = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalDepth);
            totalSizes = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalSizes);
            totalWidth = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalWidth);
            totalHeight = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalHeight);
            totalWeight = CustomConvertersExtensions.ConvertToDecimalValidation(order.metrics?.totalWeight);
            totalCubage = 0;

            retryTimes = CustomConvertersExtensions.ConvertToInt32Validation(order.retryTimes);
            slaWorkingDays = CustomConvertersExtensions.ConvertToInt32Validation(order.slaWorkingDays);

            totalETA = CustomConvertersExtensions.ConvertToInt64Validation(order.totalETA);

            Responses.Add($"{orderId}", response);

            customer = order.customer != null ? new Customer(order.customer) : new Customer();
            sender = order.sender != null ? new Sender(order.sender) : new Sender();
            owner = order.owner != null ? new Owner(order.owner) : new Owner();
            error = String.IsNullOrEmpty(order.message) && String.IsNullOrEmpty(order.error) ? new Error() : new Error(orderNumber, order.message, order.error);

            addresses.Add(order.pickupAddress != null ? new Address(order.pickupAddress, order.id) : new Address());
            addresses.Add(order.deliveryAddress != null ? new Address(order.deliveryAddress, order.customer.document, order.id) : new Address());

            order.events?.ForEach(@event =>
            {
                events.Add(new Event(@event, order.id));
            });
            
            order.items?.ForEach(item =>
            {
                items.Add(new Item(item, order.id));
            });
        }
    }
}
