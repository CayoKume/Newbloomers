using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Models
{
    public class Status
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        [SkipProperty]
        public Dictionary<int?, string> Responses { get; set; } = new Dictionary<int?, string>();

        public Status()
        {
            id = 0;
            name = String.Empty;
            description = String.Empty;
        }

        public Status(Dtos.Status status)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(status.id);
            name = status.name;
            description = status.description;
        }

        public Status(Dtos.Status status, string json)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(status.id);
            name = status.name;
            description = status.description;

            Responses.Add(id, json);
        }
    }

    public class ResponseStatus
    {
        public bool? success { get; set; }
        public List<Status> data { get; set; }
    }
}
