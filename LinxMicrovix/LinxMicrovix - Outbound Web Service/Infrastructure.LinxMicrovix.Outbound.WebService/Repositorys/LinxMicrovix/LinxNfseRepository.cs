﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxNfseRepository : ILinxNfseRepository
    {
        public LinxNfseRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNfse> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxNfse>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNfse> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNfse? record)
        {
            throw new NotImplementedException();
        }
    }
}
