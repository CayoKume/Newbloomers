using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class Voucher
    {
        public string? redemption_code { get; set; }
        public string? giftcard_id { get; set; }
        public DateTime? expiring_date { get; set; }

        public Voucher() 
        {
            redemption_code = String.Empty;
            giftcard_id = String.Empty;
            expiring_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        }

        public Voucher(Dtos.Voucher voucher)
        {
            redemption_code = voucher.redemption_code;
            giftcard_id = voucher.giftcard_id;
            expiring_date = CustomConvertersExtensions.ConvertToDateTimeValidation(voucher.expiring_date);
        }
    }
}
