using Newtonsoft.Json.Linq;

namespace AfterSale;

public interface IAPICall
{
    public Task<string?> GetAsync(string? rote, string? token);
    public Task<string?> GetAsync(string? rote, string? token, string? encodedParameters);
    public Task<string?> PostAsync(string? rote, JObject jObj);
    public Task<string?> PutAsync(string? rote, JObject jObj);
}
