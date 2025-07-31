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
    public class B2CConsultaProdutosCamposAdicionaisDetalhesRepository : IB2CConsultaProdutosCamposAdicionaisDetalhesRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler _commandHandler;

        public B2CConsultaProdutosCamposAdicionaisDetalhesRepository(ICoreRepository coreRepository, IB2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCamposAdicionaisDetalhes> records)
        {
            var table = _coreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCamposAdicionaisDetalhes());

            _coreRepository.FillSystemDataTable(table, records.ToList());

            _coreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCamposAdicionaisDetalhes> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _coreRepository.GetRecords<string>(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCamposAdicionaisDetalhes? record)
        {
            string sql = _commandHandler.CreateInsertRecordQuery(jobParameter.tableName);
            return await _coreRepository.InsertRecord(sql: sql, entity: record);
        }
    }
}
