using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosRepository : IB2CConsultaProdutosAssociadosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosAssociados> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosAssociadosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosAssociados> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosAssociados> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosAssociados());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id, records[i].codigoproduto, records[i].codigoproduto_associado, records[i].coeficiente_desconto, records[i].timestamp, records[i].portal, records[i].qtde_item, records[i].item_obrigatorio);
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

        public async Task<List<B2CConsultaProdutosAssociados>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosAssociados> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id}'";
                    else
                        identificadores += $"'{registros[i].id}', ";
                }

                string sql = $"SELECT ID, TIMESTAMP FROM B2CCONSULTAPRODUTOSASSOCIADOS WHERE ID IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosAssociados? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id], [codigoproduto], [codigoproduto_associado], [coeficiente_desconto], [timestamp], [portal], [qtde_item], [item_obrigatorio]) " +
                          "Values " +
                          "(@lastupdateon, @id, @codigoproduto, @codigoproduto_associado, @coeficiente_desconto, @timestamp, @portal, @qtde_item, @item_obrigatorio)";

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
