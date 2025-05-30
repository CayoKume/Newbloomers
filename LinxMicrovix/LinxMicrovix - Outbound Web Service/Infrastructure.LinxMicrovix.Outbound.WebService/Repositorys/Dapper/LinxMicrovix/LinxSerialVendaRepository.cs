using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxSerialVendaRepository : ILinxSerialVendaRepository
    {
        public LinxSerialVendaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSerialVenda> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSerialVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSerialVenda> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSerialVenda? record)
        {
            throw new NotImplementedException();
        }
    }
}
