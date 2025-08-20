﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxECFRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxECF? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxECF> records);
        public Task<IEnumerable<LinxECF>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxECF> registros);
    }
}
