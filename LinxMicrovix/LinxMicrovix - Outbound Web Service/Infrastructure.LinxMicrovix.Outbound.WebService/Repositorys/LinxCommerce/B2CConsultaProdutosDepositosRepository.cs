using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosDepositosRepository : IB2CConsultaProdutosDepositosRepository
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly IB2CConsultaProdutosDepositosCommandHandler _commandHandler;

        public B2CConsultaProdutosDepositosRepository(IIntegrationsCoreRepository integrationsCoreRepository, IB2CConsultaProdutosDepositosCommandHandler commandHandler)
        {
            _integrationsCoreRepository = integrationsCoreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosDepositos> records)
        {
            var table = _integrationsCoreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosDepositos());

            _integrationsCoreRepository.FillSystemDataTable(table, records.ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosDepositos> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _integrationsCoreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosDepositos? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _integrationsCoreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
