namespace Domain.Movidesk.Interfaces.Apis
{
    public interface IAPICall
    {
        public Task<string> GetAsync(string rote, string token);
        public Task<string> GetAsync(string rote, string token, string filters, string selectItens, string expandItens);
    }
}
