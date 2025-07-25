﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasItensRepository : ILinxTrocaUnificadaResumoVendasItensRepository
    {
        public LinxTrocaUnificadaResumoVendasItensRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoVendasItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxTrocaUnificadaResumoVendasItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoVendasItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoVendasItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
