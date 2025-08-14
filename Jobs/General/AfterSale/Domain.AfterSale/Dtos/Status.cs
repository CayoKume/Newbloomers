using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Dtos
{
    public class Status
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class ResponseStatus
    {
        public string? success { get; set; }
        public List<Status> data { get; set; }
    }
}
