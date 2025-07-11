using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaEspessurasRepository : IB2CConsultaEspessurasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaEspessuras> _linxMicrovixRepositoryBase;

        public B2CConsultaEspessurasRepository(ILinxMicrovixRepositoryBase<B2CConsultaEspessuras> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaEspessuras> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaEspessuras());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].codigo_espessura, records[i].nome_espessura, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaEspessuras> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].codigo_espessura}'";
                else
                    identificadores += $"'{registros[i].codigo_espessura}', ";
            }

            string sql = $"SELECT CONCAT('[', CODIGO_ESPESSURA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAESPESSURAS] WHERE CODIGO_ESPESSURA IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaEspessuras? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_espessura], [nome_espessura], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_espessura, @nome_espessura, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
