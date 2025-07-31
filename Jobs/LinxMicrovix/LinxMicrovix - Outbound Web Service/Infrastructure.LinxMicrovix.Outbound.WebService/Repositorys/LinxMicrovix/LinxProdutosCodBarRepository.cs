using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosCodBarRepository : ILinxProdutosCodBarRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxProdutosCodBarCommandHandler _commandHandler;

        public LinxProdutosCodBarRepository(ICoreRepository coreRepository, ILinxProdutosCodBarCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosCodBar> records)
        {
            var table = _coreRepository.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosCodBar());

            _coreRepository.FillSystemDataTable(table, records.ToList());

            _coreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetProductsSetorIds(LinxAPIParam jobParameter)
        {
            string sql = _commandHandler.CreateGetProductsSetorIdsQuery();
            return await _coreRepository.GetRecords<string>(sql);
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<long?> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _coreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCodBar? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _coreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}

