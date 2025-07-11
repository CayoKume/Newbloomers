using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValoresRepository : IB2CConsultaProdutosCamposAdicionaisValoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisValores> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCamposAdicionaisValoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisValores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCamposAdicionaisValores> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCamposAdicionaisValores());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_campo_valor, records[i].codigoproduto, records[i].id_campo_detalhe, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCamposAdicionaisValores> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_campo_valor}'";
                else
                    identificadores += $"'{registros[i].id_campo_valor}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_CAMPO_VALOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTES] WHERE ID_CAMPO_VALOR IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCamposAdicionaisValores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_campo_valor], [codigoproduto], [id_campo_detalhe], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_campo_valor, @codigoproduto, @id_campo_detalhe, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
