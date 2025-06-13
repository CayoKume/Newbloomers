namespace Domain.Movidesk.Interfaces.Apis
{
    public interface IAPICall
    {
        public Task<string> GetAsync(string rote, Guid? token);
        public Task<string> GetAsync(string rote, Guid? token, string filters, string selectItens, string expandItens);
    }
}
