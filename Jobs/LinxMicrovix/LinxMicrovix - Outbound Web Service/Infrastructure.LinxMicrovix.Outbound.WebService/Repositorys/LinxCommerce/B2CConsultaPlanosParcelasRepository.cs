using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPlanosParcelasRepository : IB2CConsultaPlanosParcelasRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaPlanosParcelasCommandHandler _commandHandler;

        public B2CConsultaPlanosParcelasRepository(ICoreRepository coreRepository, IB2CConsultaPlanosParcelasCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPlanosParcelas> records)
        {
            var table = _coreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPlanosParcelas());

            _coreRepository.FillSystemDataTable(table, records.ToList());

            _coreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPlanosParcelas> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _coreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPlanosParcelas? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _coreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
