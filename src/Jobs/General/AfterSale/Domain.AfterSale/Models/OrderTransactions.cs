using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class OrderTransactions
    {
        public Int32? id { get; set; }
        public Int32? refund_id { get; set; }
        public Int32? ecommerce_order_id { get; set; }
        public Int32? transaction_id { get; set; }
        public string? acquirer { get; set; }
        public string? nsu { get; set; }
        public string? tid { get; set; }
        public string? merchant_name { get; set; }
        public decimal? total_amount { get; set; }
        public DateTime? date { get; set; }

        public OrderTransactions() 
        {
            id = 0;
            refund_id = 0;
            ecommerce_order_id = 0;
            transaction_id = 0;
            acquirer = String.Empty;
            nsu = String.Empty;
            tid = String.Empty;
            merchant_name = String.Empty;
            total_amount = 0;
            date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        }

        public OrderTransactions(Dtos.OrderTransactions orderTransaction)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(orderTransaction.id);
            refund_id = CustomConvertersExtensions.ConvertToInt32Validation(orderTransaction.refund_id);
            ecommerce_order_id = CustomConvertersExtensions.ConvertToInt32Validation(orderTransaction.ecommerce_order_id);
            transaction_id = CustomConvertersExtensions.ConvertToInt32Validation(orderTransaction.transaction_id);
            acquirer = orderTransaction.acquirer;
            nsu = orderTransaction.nsu;
            tid = orderTransaction.tid;
            merchant_name = orderTransaction.merchant_name;
            total_amount = CustomConvertersExtensions.ConvertToDecimalValidation(orderTransaction.total_amount);
            date = CustomConvertersExtensions.ConvertToDateTimeValidation(orderTransaction.date);
    }
    }
}
