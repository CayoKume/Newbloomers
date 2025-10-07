using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stone.Dtos
{
    public class Pagination
    {
        public int? total { get; set; }
        public int? lastPage { get; set; }
        public int? currentPage { get; set; }
        public int? nextPage { get; set; }
    }
}
