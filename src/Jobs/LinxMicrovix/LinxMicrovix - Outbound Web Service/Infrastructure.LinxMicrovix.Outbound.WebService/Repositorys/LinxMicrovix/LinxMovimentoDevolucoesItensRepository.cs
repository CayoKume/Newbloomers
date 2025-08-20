using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoDevolucoesItensRepository : ILinxMovimentoDevolucoesItensRepository
    {
        public LinxMovimentoDevolucoesItensRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoDevolucoesItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoDevolucoesItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoDevolucoesItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoDevolucoesItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
