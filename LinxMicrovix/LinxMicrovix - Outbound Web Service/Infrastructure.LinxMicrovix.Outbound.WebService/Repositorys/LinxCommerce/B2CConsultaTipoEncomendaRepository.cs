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
    public class B2CConsultaTipoEncomendaRepository : IB2CConsultaTipoEncomendaRepository
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly IB2CConsultaTipoEncomendaCommandHandler _commandHandler;

        public B2CConsultaTipoEncomendaRepository(IIntegrationsCoreRepository integrationsCoreRepository, IB2CConsultaTipoEncomendaCommandHandler commandHandler)
        {
            _integrationsCoreRepository = integrationsCoreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTipoEncomenda> records)
        {
            var table = _integrationsCoreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaTipoEncomenda());

            _integrationsCoreRepository.FillSystemDataTable(table, records.ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTipoEncomenda> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _integrationsCoreRepository.GetRecords<string>(sql);
        }
    }
}
