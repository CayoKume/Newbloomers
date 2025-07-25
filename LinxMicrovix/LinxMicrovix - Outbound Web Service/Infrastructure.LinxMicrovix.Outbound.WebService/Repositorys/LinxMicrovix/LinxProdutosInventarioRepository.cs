using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosInventarioRepository : ILinxProdutosInventarioRepository
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ILinxProdutosInventarioCommandHandler _commandHandler;

        public LinxProdutosInventarioRepository(IIntegrationsCoreRepository integrationsCoreRepository, ILinxProdutosInventarioCommandHandler commandHandler)
        {
            _integrationsCoreRepository = integrationsCoreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosInventario> records)
        {
            var table = _integrationsCoreRepository.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosInventario());

            _integrationsCoreRepository.FillSystemDataTable(table, records.ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetProductsDepositsIds(LinxAPIParam jobParameter)
        {
            string sql = _commandHandler.CreateGetProductsDepositsIdsQuery();
            return await _integrationsCoreRepository.GetRecords<string>(sql);
        }

        public async Task<IEnumerable<LinxProdutosInventario>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosInventario> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _integrationsCoreRepository.GetRecords<LinxProdutosInventario>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosInventario? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _integrationsCoreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
