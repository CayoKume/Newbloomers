using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Entities
{
    public class Error
    {
        public string orderNumber { get; set; }
        public string message { get; set; }
        public string error { get; set; }

        public Error() { }

        public Error(string orderNumber, string message, string error)
        {
            this.orderNumber = orderNumber;
            this.message = message;
            this.error = error;
        }
    }
}
