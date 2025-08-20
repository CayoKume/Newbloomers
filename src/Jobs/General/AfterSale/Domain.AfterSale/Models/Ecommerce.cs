using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class Ecommerce
    {
        public Guid? uuid { get; set; }

        public Int32? id { get; set; }
        public Int32? address_id { get; set; }
        public Int32? ecommerce_group_id { get; set; }
        
        public string? company_name { get; set; }
        public string? trade_name { get; set; }
        public string? display_name { get; set; }
        public string? url { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? document { get; set; }
        public string? segment { get; set; }
        public string? oauth_client_id { get; set; }
        public string? provider_id { get; set; }
        public string? registration_origin { get; set; }
        public string? brand_id { get; set; }
        public string? app_name { get; set; }

        public bool? is_active { get; set; }
        public bool? maintenance_mode_global { get; set; }
        public bool? is_test { get; set; }

        public DateTime? last_order_report_date { get; set; }

        [SkipProperty]
        public Address address { get; set; }

        [SkipProperty]
        public List<Reason> reasons { get; set; } = new List<Reason>();

        [SkipProperty]
        public Dictionary<Guid?, string> Responses { get; set; } = new Dictionary<Guid?, string>();

        public Ecommerce() 
        {
            uuid = new Guid();
            id = 0;
            address_id = 0;
            ecommerce_group_id = 0;
            company_name = String.Empty;
            trade_name = String.Empty;
            display_name = String.Empty;
            url = String.Empty;
            phone = String.Empty;
            email = String.Empty;
            document = String.Empty;
            segment = String.Empty;
            oauth_client_id = String.Empty;
            provider_id = String.Empty;
            registration_origin = String.Empty;
            brand_id = String.Empty;
            app_name = String.Empty;
            is_active = false;
            maintenance_mode_global = false;
            is_test = false;
            last_order_report_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            address = new Address();
        }

        public Ecommerce(Domain.AfterSale.Dtos.Ecommerce ecommerce)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(ecommerce.id);
            uuid = CustomConvertersExtensions.ConvertToGuidValidation(ecommerce.uuid);
            ecommerce_group_id = CustomConvertersExtensions.ConvertToInt32Validation(ecommerce.ecommerce_group_id);
            company_name = ecommerce.company_name;
            trade_name = ecommerce.trade_name;
            display_name = ecommerce.display_name;
            url = ecommerce.url;
            is_active = CustomConvertersExtensions.ConvertToBooleanValidation(ecommerce.is_active);
            phone = ecommerce.phone;
            email = ecommerce.email;
            document = ecommerce.document;
            address_id = CustomConvertersExtensions.ConvertToInt32Validation(ecommerce.address_id);
            maintenance_mode_global = CustomConvertersExtensions.ConvertToBooleanValidation(ecommerce.maintenance_mode_global);
            last_order_report_date = CustomConvertersExtensions.ConvertToDateTimeValidation(ecommerce.last_order_report_date);
            is_test = CustomConvertersExtensions.ConvertToBooleanValidation(ecommerce.is_test);
            segment = ecommerce.segment;
            oauth_client_id = ecommerce.oauth_client_id;
            provider_id = ecommerce.provider_id;
            registration_origin = ecommerce.registration_origin;
            brand_id = ecommerce.brand_id;
            app_name = ecommerce.app_name;
            address = ecommerce.address != null ? new Address(ecommerce.address) : new Address();

            ecommerce.reasons?.ForEach(reason =>
                reasons.Add(new Reason(reason)
            ));
        }

        public Ecommerce(Domain.AfterSale.Dtos.Ecommerce ecommerce, string json)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(ecommerce.id);
            uuid = CustomConvertersExtensions.ConvertToGuidValidation(ecommerce.uuid);
            ecommerce_group_id = CustomConvertersExtensions.ConvertToInt32Validation(ecommerce.ecommerce_group_id);
            company_name = ecommerce.company_name;
            trade_name = ecommerce.trade_name;
            display_name = ecommerce.display_name;
            url = ecommerce.url;
            is_active = CustomConvertersExtensions.ConvertToBooleanValidation(ecommerce.is_active);
            phone = ecommerce.phone;
            email = ecommerce.email;
            document = ecommerce.document;
            address_id = CustomConvertersExtensions.ConvertToInt32Validation(ecommerce.address_id);
            maintenance_mode_global = CustomConvertersExtensions.ConvertToBooleanValidation(ecommerce.maintenance_mode_global);
            last_order_report_date = CustomConvertersExtensions.ConvertToDateTimeValidation(ecommerce.last_order_report_date);
            is_test = CustomConvertersExtensions.ConvertToBooleanValidation(ecommerce.is_test);
            segment = ecommerce.segment;
            oauth_client_id = ecommerce.oauth_client_id;
            provider_id = ecommerce.provider_id;
            registration_origin = ecommerce.registration_origin;
            brand_id = ecommerce.brand_id;
            app_name = ecommerce.app_name;
            address = ecommerce.address != null ? new Address(ecommerce.address) : new Address();

            ecommerce.reasons?.ForEach(reason =>
                reasons.Add(new Reason(reason)
            ));

            Responses.Add(uuid, json);
        }
    }
}