﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionaisRepository : ILinxMovimentoAcoesPromocionaisRepository
    {
        public LinxMovimentoAcoesPromocionaisRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoAcoesPromocionais> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoAcoesPromocionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoAcoesPromocionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoAcoesPromocionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
