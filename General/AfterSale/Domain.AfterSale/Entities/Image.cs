using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AfterSale.Entities
{
    public class Image
    {
        public int? id { get; set; }
        public string? product_id { get; set; }
        public string? image_path { get; set; }
        public string? image_url { get; set; }
    }
}
