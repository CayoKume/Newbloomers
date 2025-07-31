using Newtonsoft.Json.Linq;

namespace Domain.Stone.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> GetAsync(string? rote, string? token);
        public Task<string?> PostAsync(string? rote, JObject jObj);
        public Task<string?> DeleteAsync(string? rote, JObject jObj);
    }
}
