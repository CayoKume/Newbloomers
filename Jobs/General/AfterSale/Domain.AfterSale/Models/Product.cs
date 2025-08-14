using Domain.Core.Extensions;

namespace Domain.AfterSale.Models
{
    public class Product
    {
        public int? id { get; set; }
        public int? order_id { get; set; }
        public int? reverse_id { get; set; }
        public int? motive_id { get; set; }
        public int? ecommerce_order_product_id { get; set; }
        public int? refund_id { get; set; }
        public int? qty { get; set; }
        public int? requested_qty { get; set; }
        public int? received_qty { get; set; }

        public string? product_received_comment { get; set; }
        public string? comments { get; set; }
        public string? reverse_action { get; set; }
        public string? customer_retention_method_id { get; set; }
        public string? protocol { get; set; }
        public string? product_id { get; set; }
        public string? hash { get; set; }
        public string? name { get; set; }
        public string? sku { get; set; }
        public string? price { get; set; }
        public string? selling_price { get; set; }
        public string? weight { get; set; }
        public string? returned_invoice { get; set; }
        public string? invoice { get; set; }

        [SkipProperty]
        public Reason reason { get; set; }

        public Product() 
        {
            id = 0;
            order_id = 0;
            reverse_id = 0;
            motive_id = 0;
            ecommerce_order_product_id = 0;
            refund_id = 0;
            qty = 0;
            requested_qty = 0;
            received_qty = 0;
            product_received_comment = String.Empty;
            comments = String.Empty;
            reverse_action = String.Empty;
            customer_retention_method_id = String.Empty;
            protocol = String.Empty;
            product_id = String.Empty;
            hash = String.Empty;
            name = String.Empty;
            sku = String.Empty;
            price = String.Empty;
            selling_price = String.Empty;
            weight = String.Empty;
            returned_invoice = String.Empty;
            invoice = String.Empty;
            reason = new Reason();
        }

        public Product(Dtos.Product product)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(product.id);
            order_id = CustomConvertersExtensions.ConvertToInt32Validation(product.order_id);
            reverse_id = CustomConvertersExtensions.ConvertToInt32Validation(product.reverse_id);
            motive_id = CustomConvertersExtensions.ConvertToInt32Validation(product.motive_id);
            ecommerce_order_product_id = CustomConvertersExtensions.ConvertToInt32Validation(product.ecommerce_order_product_id);
            refund_id = CustomConvertersExtensions.ConvertToInt32Validation(product.refund_id);
            qty = CustomConvertersExtensions.ConvertToInt32Validation(product.qty);
            requested_qty = CustomConvertersExtensions.ConvertToInt32Validation(product.requested_qty);
            received_qty = CustomConvertersExtensions.ConvertToInt32Validation(product.received_qty);

            product_received_comment = product.product_received_comment;
            comments = product.comments;
            reverse_action = product.reverse_action;
            customer_retention_method_id = product.customer_retention_method_id;
            protocol = product.protocol;
            product_id = product.product_id;
            hash = product.hash;
            name = product.name;
            sku = product.sku;
            price = product.price;
            selling_price = product.selling_price;
            weight = product.weight;
            returned_invoice = product.returned_invoice;
            invoice = product.invoice;
            reason = product.reason != null ? new Reason(product.reason) : new Reason();
        }
    }
}
