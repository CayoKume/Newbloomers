using Newtonsoft.Json.Linq;

namespace Domain.FlashCourier.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(string? token, JObject jObject, string? rote);
        public Task<string?> PostAsync(string? userName, string? password, JArray jObject, string? rote);
    }
}
