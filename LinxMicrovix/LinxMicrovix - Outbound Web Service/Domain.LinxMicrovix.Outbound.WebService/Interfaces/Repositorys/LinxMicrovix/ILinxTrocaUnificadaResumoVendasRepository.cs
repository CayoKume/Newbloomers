﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxTrocaUnificadaResumoVendasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoVendas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoVendas> records);
        public Task<IEnumerable<LinxTrocaUnificadaResumoVendas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoVendas> registros);
    }
}
