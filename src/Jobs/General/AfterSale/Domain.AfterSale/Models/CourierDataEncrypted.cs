using Domain.Core.Extensions;

namespace Domain.AfterSale.Models
{
    public class CourierDataEncrypted
    {
        public string posting_card { get; set; }
        public bool is_store_seller_contract { get; set; }

        public CourierDataEncrypted() 
        {
            posting_card = String.Empty;
            is_store_seller_contract = false;
        }

        public CourierDataEncrypted(Domain.AfterSale.Dtos.CourierDataEncrypted courierDataEncrypted)
        {
            posting_card = courierDataEncrypted.posting_card;
            is_store_seller_contract = CustomConvertersExtensions.ConvertToBooleanValidation(courierDataEncrypted.is_store_seller_contract);
        }
    }
}
