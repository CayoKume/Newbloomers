using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosStatusRepository : IB2CConsultaProdutosStatusRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosStatus> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosStatusRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosStatus> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosStatus> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosStatus());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].codigoproduto, records[i].referencia, records[i].ativo, records[i].b2c, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, IList<B2CConsultaProdutosStatus> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].codigoproduto}'";
                else
                    identificadores += $"'{registros[i].codigoproduto}', ";
            }

            string sql = $"SELECT CONCAT('[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSSTATUS] WHERE CODIGOPRODUTO IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosStatus? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigoproduto], [referencia], [ativo], [b2c], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigoproduto, @referencia, @ativo, @b2c, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
