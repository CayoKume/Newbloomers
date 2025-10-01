using Domain.Stone.Entities;

namespace Domain.Stone.Interfaces.Repository
{
    public interface IStoneRepository
    {
        public Task<bool> InsertRecord(Order? record);
        public Task<bool> BulkInsertIntoTableRaw(IList<Order> records, Guid? parentExecutionGUID);
        public Task<IEnumerable<string?>> GetRegistersExists();
        public Task<IEnumerable<Parameters?>> GetParameters();
    }
}
