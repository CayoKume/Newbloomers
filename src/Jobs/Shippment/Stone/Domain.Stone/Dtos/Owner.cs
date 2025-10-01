using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Dtos
{
    public class Owner
    {
        public string id { get; set; }
        public string name { get; set; }
        public string document { get; set; }
        public string phoneNumber { get; set; }
        public string logisticAccountId { get; set; }
    }
}
