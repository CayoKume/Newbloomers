using Domain.Core.Extensions;

namespace Domain.AfterSale.Models
{
    public class Type
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public Type() 
        {
            id = 0;
            name = String.Empty;
            description = String.Empty;
        }

        public Type(Dtos.Type type)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(type.id);
            name = type.name;
            description = type.description;
        }
    }
}
