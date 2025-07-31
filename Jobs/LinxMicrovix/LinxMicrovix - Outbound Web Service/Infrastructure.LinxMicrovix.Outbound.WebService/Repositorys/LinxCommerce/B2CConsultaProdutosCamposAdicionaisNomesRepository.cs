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
    public class B2CConsultaProdutosCamposAdicionaisNomesRepository : IB2CConsultaProdutosCamposAdicionaisNomesRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaProdutosCamposAdicionaisNomesCommandHandler _commandHandler;

        public B2CConsultaProdutosCamposAdicionaisNomesRepository(ICoreRepository coreRepository, IB2CConsultaProdutosCamposAdicionaisNomesCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCamposAdicionaisNomes> records)
        {
            var table = _coreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCamposAdicionaisNomes());

            _coreRepository.FillSystemDataTable(table, records.ToList());

            _coreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCamposAdicionaisNomes> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _coreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCamposAdicionaisNomes? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _coreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
