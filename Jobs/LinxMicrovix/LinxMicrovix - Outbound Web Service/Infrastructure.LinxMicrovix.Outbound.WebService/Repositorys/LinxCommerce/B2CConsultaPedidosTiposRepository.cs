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
    public class B2CConsultaPedidosTiposRepository : IB2CConsultaPedidosTiposRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaPedidosTiposCommandHandler _commandHandler;

        public B2CConsultaPedidosTiposRepository(ICoreRepository coreRepository, IB2CConsultaPedidosTiposCommandHandler commandHandler)
        {
            _coreRepository = coreRepository;
            _commandHandler = commandHandler;
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosTipos> records)
        {
            var table = _coreRepository.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPedidosTipos());

            _coreRepository.FillSystemDataTable(table, records.ToList());

            _coreRepository.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPedidosTipos> registros)
        {
            string sql = _commandHandler.CreateGetRegistersExistsQuery(registros);
            return await _coreRepository.GetRecords<string>(sql);
        }
    }
}
