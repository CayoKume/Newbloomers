﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxLojasParametrosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojasParametros? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojasParametros> records);
        public Task<IEnumerable<LinxLojasParametros>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLojasParametros> registros);
    }
}
