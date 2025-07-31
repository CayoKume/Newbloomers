﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosTabelasPrecosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelasPrecos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelasPrecos> records);
        public Task<IEnumerable<string?>> GetProductsTablesIds(LinxAPIParam jobParameter);
        public Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros);
    }
}
