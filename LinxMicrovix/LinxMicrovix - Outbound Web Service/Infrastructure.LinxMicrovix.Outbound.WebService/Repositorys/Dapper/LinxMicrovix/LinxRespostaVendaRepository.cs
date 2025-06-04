using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxRespostaVendaRepository : ILinxRespostaVendaRepository
    {
        public LinxRespostaVendaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRespostaVenda> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxRespostaVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRespostaVenda> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRespostaVenda? record)
        {
            throw new NotImplementedException();
        }
    }
}
