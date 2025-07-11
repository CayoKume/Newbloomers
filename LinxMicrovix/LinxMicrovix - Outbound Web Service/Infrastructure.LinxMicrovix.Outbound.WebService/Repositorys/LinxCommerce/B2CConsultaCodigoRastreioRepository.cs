using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaCodigoRastreioRepository : IB2CConsultaCodigoRastreioRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaCodigoRastreio> _linxMicrovixRepositoryBase;

        public B2CConsultaCodigoRastreioRepository(ILinxMicrovixRepositoryBase<B2CConsultaCodigoRastreio> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaCodigoRastreio> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaCodigoRastreio());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_pedido, records[i].documento, records[i].serie, records[i].codigo_rastreio, records[i].sequencia_volume,
                    records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaCodigoRastreio> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].codigo_rastreio}'";
                else
                    identificadores += $"'{registros[i].codigo_rastreio}', ";
            }

            string sql = $"SELECT CONCAT('[', CODIGO_RASTREIO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACODIGORASTREIO] WHERE CODIGO_RASTREIO IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaCodigoRastreio? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_pedido], [documento], [serie], [codigo_rastreio], [sequencia_volume], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido, @documento, @serie, @codigo_rastreio, @sequencia_volume, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
