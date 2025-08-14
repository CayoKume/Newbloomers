using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class TotalAmountHistories
    {
        public Int32 id { get; set; }
        public decimal? total_amount { get; set; }
        public DateTime? date { get; set; }
        public Int32 refund_id { get; set; }

        [SkipProperty]
        public Type type { get; set; }

        [SkipProperty]
        public Refund Refund { get; set; }

        public TotalAmountHistories() 
        {
            id = 0;
            total_amount = 0;
            date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            refund_id = 0;
            type = new Type();
            Refund = new Refund();
        }

        public TotalAmountHistories(Dtos.TotalAmountHistories totalAmountHistories)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(totalAmountHistories.id);
            total_amount = CustomConvertersExtensions.ConvertToDecimalValidation(totalAmountHistories.total_amount);
            date = CustomConvertersExtensions.ConvertToDateTimeValidation(totalAmountHistories?.date);
            refund_id = CustomConvertersExtensions.ConvertToInt32Validation(totalAmountHistories.refund_id);
            type = totalAmountHistories.type != null ? new Models.Type(totalAmountHistories.type) : new Type();
            Refund = totalAmountHistories.Refund != null ? new Models.Refund(totalAmountHistories.Refund) : new Refund();
        }
    }
}
