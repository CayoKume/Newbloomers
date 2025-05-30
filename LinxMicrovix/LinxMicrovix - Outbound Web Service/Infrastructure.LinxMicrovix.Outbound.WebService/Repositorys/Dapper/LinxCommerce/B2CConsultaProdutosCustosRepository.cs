using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaProdutosCustosRepository : IB2CConsultaProdutosCustosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosCustos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCustosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosCustos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCustos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCustos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_produtos_custos, records[i].codigoproduto, records[i].empresa, records[i].custoicms1, records[i].ipi1, records[i].markup, records[i].customedio,
                        records[i].frete1, records[i].precisao, records[i].precominimo, records[i].dt_update, records[i].custoliquido, records[i].precovenda, records[i].custototal, records[i].precocompra, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaProdutosCustos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCustos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_produtos_custos}'";
                    else
                        identificadores += $"'{registros[i].id_produtos_custos}', ";
                }

                string sql = $"SELECT ID_PRODUTOS_CUSTOS, TIMESTAMP FROM B2CCONSULTAPRODUTOSCUSTOS WHERE ID_PRODUTOS_CUSTOS IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCustos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_produtos_custos], [codigoproduto], [empresa], [custoicms1], [ipi1], [markup], [customedio], [frete1], [precisao], [precominimo], [dt_update], [custoliquido], [precovenda], [custototal], [precocompra], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_produtos_custos, @codigoproduto, @empresa, @custoicms1, @ipi1, @markup, @customedio, @frete1, @precisao, @precominimo, @dt_update, @custoliquido, @precovenda, @custototal, @precocompra, @timestamp, @portal)";

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
