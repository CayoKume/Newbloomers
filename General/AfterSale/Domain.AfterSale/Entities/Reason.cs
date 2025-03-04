using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AfterSale.Entities
{
    public class Reason
    {
        public int? id { get; set; }
        public int? ecommerce_id { get; set; }
        public string? description { get; set; }
        public string? reason_category_id { get; set; }
        public string? action { get; set; }
        public bool? should_approve { get; set; }
        public string? upload_image { get; set; }
        public bool? show_product_grid { get; set; }
        public string? ord { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
