using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Models.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesRepository : IB2CConsultaProdutosDetalhesRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosDetalhes> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosDetalhesRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosDetalhes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosDetalhes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosDetalhes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_prod_det, records[i].empresa, records[i].saldo, records[i].controla_lote, records[i].nomeproduto_alternativo, records[i].timestamp, records[i].referencia,
                        records[i].localizacao, records[i].portal, records[i].tempo_preparacao_estoque);
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

        public async Task<List<B2CConsultaProdutosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosDetalhes> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_prod_det}'";
                    else
                        identificadores += $"'{registros[i].id_prod_det}', ";
                }

                string sql = $"SELECT ID_PROD_DET, TIMESTAMP FROM B2CCONSULTAPRODUTOSDETALHES WHERE ID_PROD_DET IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosDetalhes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_prod_det], [codigoproduto], [empresa], [saldo], [controla_lote], [nomeproduto_alternativo], [timestamp], [referencia], [localizacao], [portal], [tempo_preparacao_estoque]) " +
                          "Values " +
                          "(@lastupdateon, @id_prod_det, @codigoproduto, @empresa, @saldo, @controla_lote, @nomeproduto_alternativo, @timestamp, @referencia, @localizacao, @portal, @tempo_preparacao_estoque)";

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
