using Newtonsoft.Json.Linq;

namespace Domain.Jadlog.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> GetAsync(string? rote, string? token, string? clientName, string? contentType);
        public Task<string?> PostAsync(string? rote, string? token, string? clientName, string? contentType, JObject jObj);
    }
}
