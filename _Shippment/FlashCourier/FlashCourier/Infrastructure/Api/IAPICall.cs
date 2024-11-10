using Newtonsoft.Json.Linq;

namespace FlashCourier.Infrastructure.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(string? token, JObject jObject, string? rote);
        public Task<string?> PostAsync(string? userName, string? password, JArray jObject, string? rote);
    }
}
