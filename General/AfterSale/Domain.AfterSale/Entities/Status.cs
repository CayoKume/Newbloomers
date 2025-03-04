using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AfterSale.Entities
{
    public class Status
    {
        public int? id { get; set; }
        public string? service_code { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class GetStatus
    {
        public bool? success { get; set; }
        public List<Status> data { get; set; }
    }
}
