﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxDadosOpticosDavRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDadosOpticosDav? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDadosOpticosDav> records);
        public Task<IEnumerable<LinxDadosOpticosDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDadosOpticosDav> registros);
    }
}
