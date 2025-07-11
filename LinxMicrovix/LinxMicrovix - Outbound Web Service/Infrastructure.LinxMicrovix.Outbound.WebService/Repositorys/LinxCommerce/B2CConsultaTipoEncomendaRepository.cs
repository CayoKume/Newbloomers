using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaTipoEncomendaRepository : IB2CConsultaTipoEncomendaRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaTipoEncomenda> _linxMicrovixRepositoryBase;

        public B2CConsultaTipoEncomendaRepository(ILinxMicrovixRepositoryBase<B2CConsultaTipoEncomenda> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTipoEncomenda> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaTipoEncomenda());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_tipo_encomenda, records[i].nm_tipo_encomenda, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTipoEncomenda> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_tipo_encomenda}'";
                else
                    identificadores += $"'{registros[i].id_tipo_encomenda}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_TIPO_ENCOMENDA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CConsultaTipoEncomenda] WHERE ID_TIPO_ENCOMENDA IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }
    }
}
