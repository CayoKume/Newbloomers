using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoReshopItensRepository : ILinxMovimentoReshopItensRepository
    {
        public LinxMovimentoReshopItensRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoReshopItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoReshopItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoReshopItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoReshopItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
