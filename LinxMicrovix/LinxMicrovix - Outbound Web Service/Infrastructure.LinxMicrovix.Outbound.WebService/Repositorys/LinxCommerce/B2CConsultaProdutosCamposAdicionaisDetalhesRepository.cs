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
    public class B2CConsultaProdutosCamposAdicionaisDetalhesRepository : IB2CConsultaProdutosCamposAdicionaisDetalhesRepository
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly IB2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler _commandHandler;

        public B2CConsultaProdutosCamposAdicionaisDetalhesRepository(IIntegrationsCoreRepository integrationsCoreRepository, IB2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler commandHandler)
        {
            _integrationsCoreRepository = integrationsCoreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCamposAdicionaisDetalhes> records)
        {
            var table = _integrationsCoreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCamposAdicionaisDetalhes());

            _integrationsCoreRepository.FillSystemDataTable(table, records.ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCamposAdicionaisDetalhes> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _integrationsCoreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCamposAdicionaisDetalhes? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _integrationsCoreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
