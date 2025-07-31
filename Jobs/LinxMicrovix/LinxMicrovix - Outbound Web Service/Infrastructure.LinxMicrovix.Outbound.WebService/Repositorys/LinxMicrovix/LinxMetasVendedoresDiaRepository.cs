﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMetasVendedoresDiaRepository : ILinxMetasVendedoresDiaRepository
    {
        public LinxMetasVendedoresDiaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetasVendedoresDia> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMetasVendedoresDia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetasVendedoresDia> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetasVendedoresDia? record)
        {
            throw new NotImplementedException();
        }
    }
}
