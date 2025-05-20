using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Infrastructure.IntegrationsCore.Data;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.EFCore.LinxCommerce
{
    public class B2CConsultaClassificacaoRepository : IB2CConsultaClassificacaoRepository
    {
        private readonly AppDbContext _context;

        public B2CConsultaClassificacaoRepository(AppDbContext context) =>
            _context = context;

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClassificacao> records)
        {
            try
            {
                _context.AddRange(records);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<B2CConsultaClassificacao>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClassificacao> registros)
        {
            //var keysToFind = registros.Where(r => r.codigo_classificacao != default).Select(r => r.codigo_classificacao).ToList();

            //if (keysToFind.Any())
            //{
            //    return await _context.B2CConsultaClassificacoes
            //        .Where(existing => keysToFind.Contains(existing.Id))
            //        .ToListAsync();
            //}

            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClassificacao? record)
        {
            throw new NotImplementedException();
        }
    }
}
