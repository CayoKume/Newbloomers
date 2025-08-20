using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
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

        public Reason() 
        {
            id = 0;
            ecommerce_id = 0;
            description = String.Empty;
            reason_category_id = String.Empty;
            action = String.Empty;
            should_approve = false;
            upload_image = String.Empty;
            show_product_grid = false;
            ord = String.Empty;
            created_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar); 
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            deleted_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        }

        public Reason(Domain.AfterSale.Dtos.Reason reason)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(reason.id);
            ecommerce_id = CustomConvertersExtensions.ConvertToInt32Validation(reason.ecommerce_id);
            description = reason.description;
            reason_category_id = reason.reason_category_id;
            action = reason.action;
            should_approve = CustomConvertersExtensions.ConvertToBooleanValidation(reason.should_approve);
            upload_image = reason.upload_image;
            show_product_grid = CustomConvertersExtensions.ConvertToBooleanValidation(reason.show_product_grid);
            ord = reason.ord;
            created_at = CustomConvertersExtensions.ConvertToDateTimeValidation(reason.created_at);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(reason.updated_at);
            deleted_at = CustomConvertersExtensions.ConvertToDateTimeValidation(reason.deleted_at);
        }
    }
}
