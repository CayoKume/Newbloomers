using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosRepository : ILinxMovimentoRemessasAcertosRepository
    {
        public LinxMovimentoRemessasAcertosRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasAcertos> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoRemessasAcertos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertos? record)
        {
            throw new NotImplementedException();
        }
    }
}
