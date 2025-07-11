using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesRepository : IB2CConsultaProdutosInformacoesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosInformacoes> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosInformacoesRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosInformacoes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosInformacoes> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosInformacoes());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_produtos_informacoes, records[i].codigoproduto, records[i].informacoes_produto, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosInformacoes> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_produtos_informacoes}'";
                else
                    identificadores += $"'{registros[i].id_produtos_informacoes}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_PRODUTOS_INFORMACOES, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTES] WHERE ID_PRODUTOS_INFORMACOES IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosInformacoes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_produtos_informacoes], [codigoproduto], [informacoes_produto], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_produtos_informacoes, @codigoproduto, @informacoes_produto,, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
