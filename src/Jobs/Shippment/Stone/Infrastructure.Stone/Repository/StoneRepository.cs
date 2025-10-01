using Application.Stone.Interfaces.Handlers.Commands;
using Domain.Core.Interfaces;
using Domain.Stone.Entities;
using Domain.Stone.Interfaces.Repository;

namespace Infrastructure.Stone.Repository
{
    public class StoneRepository : IStoneRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IStoneLogisticaCommandHandler _commandHandler;

        public StoneRepository(ICoreRepository coreRepository, IStoneLogisticaCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public async Task<bool> BulkInsertIntoTableRaw(IList<Order> records, Guid? parentExecutionGUID)
        {
            var orderTable = _coreRepository.CreateSystemDataTable("StoneLogisticaOrders", new Order());
            var customerTable = _coreRepository.CreateSystemDataTable("StoneLogisticaCustomers", new Customer());
            var senderTable = _coreRepository.CreateSystemDataTable("StoneLogisticaSenders", new Sender());
            var addressTable = _coreRepository.CreateSystemDataTable("StoneLogisticaAddresses", new Address());
            var itemTable = _coreRepository.CreateSystemDataTable("StoneLogisticaItems", new Item());
            var eventTable = _coreRepository.CreateSystemDataTable("StoneLogisticaEvents", new Event());
            var ownerTable = _coreRepository.CreateSystemDataTable("StoneLogisticaOwner", new Owner());
            var errorsTable = _coreRepository.CreateSystemDataTable("StoneLogisticaErrors", new Error());

            var orders = records.Select(x => x).Where(x => x.orderId != new Guid()).ToList();
            var errors = records.Select(x => x.error).Where(x => x.orderNumber != null);
            var owner = records.Select(x => x.owner).Where(x => x.document != null).GroupBy(x => x.ownerId).Select(x => x.FirstOrDefault()).FirstOrDefault();
            var customers = records.Select(x => x.customer).Where(x => x.document != null).GroupBy(x => x.document).Select(x => x.FirstOrDefault()).ToList();
            var senders = records.Select(x => x.sender).Where(x => x.document != null).GroupBy(x => x.document).Select(x => x.FirstOrDefault()).ToList();
            var addresses = records.SelectMany(x => x.addresses).Where(x => x.chave != null).GroupBy(x => x.chave).Select(x => x.FirstOrDefault());

            var owners = new List<Owner>();
            owners.Add(owner);
            owners.Add(new Owner());
            customers.Add(new Customer());

            _coreRepository.FillSystemDataTable(ownerTable, owners);
            _coreRepository.FillSystemDataTable(errorsTable, errors.ToList());
            _coreRepository.FillSystemDataTable(orderTable, orders);
            _coreRepository.FillSystemDataTable(customerTable, customers);
            _coreRepository.FillSystemDataTable(senderTable, senders);
            _coreRepository.FillSystemDataTable(addressTable, addresses.ToList());
            _coreRepository.FillSystemDataTable(eventTable, records.SelectMany(x => x.events).ToList());
            _coreRepository.FillSystemDataTable(itemTable, records.SelectMany(x => x.items).ToList());

            _coreRepository.BulkInsertIntoTableRaw(errorsTable);
            _coreRepository.BulkInsertIntoTableRaw(orderTable);
            _coreRepository.BulkInsertIntoTableRaw(customerTable);
            _coreRepository.BulkInsertIntoTableRaw(senderTable);
            _coreRepository.BulkInsertIntoTableRaw(ownerTable);
            _coreRepository.BulkInsertIntoTableRaw(addressTable);
            _coreRepository.BulkInsertIntoTableRaw(eventTable);
            _coreRepository.BulkInsertIntoTableRaw(itemTable);

            await _coreRepository.CallDbProcMerge("general", errorsTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", ownerTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", senderTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", customerTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", orderTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", itemTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", addressTable.TableName, parentExecutionGUID);
            await _coreRepository.CallDbProcMerge("general", eventTable.TableName, parentExecutionGUID);

            return true;
        }

        public async Task<IEnumerable<Parameters?>> GetParameters()
        {
            string sql = _commandHandler.CreateGetParametersQuery();
            return await _coreRepository.GetRecords<Parameters>(sql);
        }

        public async Task<IEnumerable<string?>> GetRegistersExists()
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery();
            return await _coreRepository.GetRecords<string>(sql);
        }

        public Task<bool> InsertRecord(Order? record)
        {
            throw new NotImplementedException();
        }
    }
}
