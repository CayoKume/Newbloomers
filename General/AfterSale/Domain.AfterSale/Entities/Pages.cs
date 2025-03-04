using System.Collections.Generic;
using System.Text;

namespace Domain.AfterSale.Entities
{
    public class Pages
    {
        public TitleDescription introduction { get; set; }
        public TitleDescription select_source { get; set; }
        public TitleDescription order { get; set; }
        public TitleDescription products { get; set; }
        public TitleDescription optional_commentary { get; set; }
        public TitleDescription shipping { get; set; }
        public TitleDescription resume { get; set; }
        public TitleDescription finish { get; set; }
        public TitleDescription customer { get; set; }
        public TitleDescription customer_products { get; set; }
        public TitleDescription seller { get; set; }
        public TitleDescription email_by_customer { get; set; }
    }

    public class TitleDescription
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }
}
