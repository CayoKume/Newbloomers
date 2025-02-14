using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecosRepository : IB2CConsultaProdutosTabelasPrecosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosTabelasPrecos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosTabelasPrecosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosTabelasPrecos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosTabelasPrecos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosTabelasPrecos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_prod_tab_preco, records[i].id_tabela, records[i].codigoproduto, records[i].precovenda, records[i].timestamp, records[i].portal);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<B2CConsultaProdutosTabelasPrecos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosTabelasPrecos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_prod_tab_preco}'";
                    else
                        identificadores += $"'{registros[i].id_prod_tab_preco}', ";
                }

                string sql = $"SELECT ID_PROD_TAB_PRECO, TIMESTAMP FROM B2CCONSULTACLIENTES WHERE ID_PROD_TAB_PRECO IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosTabelasPrecos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_prod_tab_preco], [id_tabela], [codigoproduto], [precovenda], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_prod_tab_preco, @id_tabela, @codigoproduto, @precovenda, @timestamp, @portal)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
