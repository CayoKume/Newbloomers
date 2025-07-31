using Domain.Movidesk.Entities;

namespace Domain.Movidesk.Interfaces.Repositorys
{
    public interface IMovideskRepository
    {
        public Task<Parameters> GetTokenAsync();
    }
}
