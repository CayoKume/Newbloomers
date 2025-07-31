﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxTradeinParceiroRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTradeinParceiro? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTradeinParceiro> records);
        public Task<IEnumerable<LinxTradeinParceiro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTradeinParceiro> registros);
    }
}
