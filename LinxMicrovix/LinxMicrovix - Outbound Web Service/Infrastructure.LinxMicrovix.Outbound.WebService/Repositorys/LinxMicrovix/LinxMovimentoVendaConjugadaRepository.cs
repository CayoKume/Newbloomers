using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoVendaConjugadaRepository : ILinxMovimentoVendaConjugadaRepository
    {
        public LinxMovimentoVendaConjugadaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoVendaConjugada> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoVendaConjugada>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoVendaConjugada> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoVendaConjugada? record)
        {
            throw new NotImplementedException();
        }
    }
}
