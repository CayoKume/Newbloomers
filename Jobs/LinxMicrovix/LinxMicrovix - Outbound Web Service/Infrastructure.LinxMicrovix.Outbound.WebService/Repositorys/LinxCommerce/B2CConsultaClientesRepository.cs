using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaClientesRepository : IB2CConsultaClientesRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClientesCommandHandler _commandHandler;

        public B2CConsultaClientesRepository(ICoreRepository coreRepository, IB2CConsultaClientesCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientes> records)
        {
            var table = _coreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaClientes());

            _coreRepository.FillSystemDataTable(table, records.ToList());

            _coreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientes? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _coreRepository.InsertRecord(sql: sql, entity: record);
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<string?> registros)
        {
            const int batchSize = 1000;
            var resultList = new List<string?>();

            for (int i = 0; i < registros.Count; i += batchSize)
            {
                var batch = registros.Skip(i).Take(batchSize).ToList();
                if (batch.Any())
                {
                    string sql = _commandHandler.CreateGetRegistersExistsQuery(batch);
                    var result = await _coreRepository.GetRecords<string>(sql);
                    resultList.AddRange(result);
                }
            }

            return resultList;
        }
    }
}
