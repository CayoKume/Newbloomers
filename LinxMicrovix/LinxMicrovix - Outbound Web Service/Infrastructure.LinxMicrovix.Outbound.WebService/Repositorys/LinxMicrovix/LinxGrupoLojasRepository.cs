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
    public class LinxGrupoLojasRepository : ILinxGrupoLojasRepository
    {
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ILinxGrupoLojasCommandHandler _commandHandler;

        public LinxGrupoLojasRepository(IIntegrationsCoreRepository integrationsCoreRepository, ILinxGrupoLojasCommandHandler commandHandler)
        {
            _integrationsCoreRepository = integrationsCoreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxGrupoLojas> records)
        {
            var table = _integrationsCoreRepository.CreateSystemDataTable(jobParameter.tableName, new LinxGrupoLojas());

            _integrationsCoreRepository.FillSystemDataTable(table, records.ToList());

            _integrationsCoreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists()
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery();
            return await _integrationsCoreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxGrupoLojas? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _integrationsCoreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
