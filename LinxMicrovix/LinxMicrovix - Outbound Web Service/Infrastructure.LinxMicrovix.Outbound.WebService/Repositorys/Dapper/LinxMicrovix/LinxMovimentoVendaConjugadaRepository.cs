using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxMovimentoVendaConjugada>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoVendaConjugada> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoVendaConjugada? record)
        {
            throw new NotImplementedException();
        }
    }
}
