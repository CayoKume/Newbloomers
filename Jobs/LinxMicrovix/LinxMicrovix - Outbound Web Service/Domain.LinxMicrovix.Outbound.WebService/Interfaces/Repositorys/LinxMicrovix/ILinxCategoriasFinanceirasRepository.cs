﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCategoriasFinanceirasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCategoriasFinanceiras? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCategoriasFinanceiras> records);
        public Task<IEnumerable<LinxCategoriasFinanceiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCategoriasFinanceiras> registros);
    }
}
