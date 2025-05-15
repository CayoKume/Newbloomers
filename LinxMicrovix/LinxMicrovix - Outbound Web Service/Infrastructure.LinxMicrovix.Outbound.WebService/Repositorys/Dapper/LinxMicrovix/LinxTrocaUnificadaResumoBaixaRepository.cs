using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixaRepository : ILinxTrocaUnificadaResumoBaixaRepository
    {
        public LinxTrocaUnificadaResumoBaixaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoBaixa> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxTrocaUnificadaResumoBaixa>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoBaixa> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoBaixa? record)
        {
            throw new NotImplementedException();
        }
    }
}
