using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasRepository : IB2CConsultaProdutosCampanhasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCampanhas> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCampanhasRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCampanhas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCampanhas> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCampanhas());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].codigo_campanha, records[i].nome_campanha, records[i].vigencia_inicio, records[i].vigencia_fim, records[i].observacao, records[i].ativo, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCampanhas> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].codigo_campanha}'";
                else
                    identificadores += $"'{registros[i].codigo_campanha}', ";
            }

            string sql = $"SELECT CONCAT('[', CODIGO_CAMPANHA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCAMPANHAS] WHERE CODIGO_CAMPANHA IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCampanhas? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_campanha], [nome_campanha], [vigencia_inicio], [vigencia_fim], [observacao], [ativo], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_campanha, @nome_campanha, @vigencia_inicio, @vigencia_fim, @observacao, @ativo, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
