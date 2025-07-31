using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Entities
{
    public class Status
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        [SkipProperty]
        [NotMapped]
        public Dictionary<int?, string> Responses { get; set; } = new Dictionary<int?, string>();

        public Status() { }

        public Status(Status status, string json)
        {
            id = status.id;
            name = status.name;
            description = status.description;

            Responses.Add(status.id, json);
        }
    }

    public class ResponseStatus
    {
        public bool? success { get; set; }
        public List<Status> data { get; set; }
    }
}
