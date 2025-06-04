using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaColecoesRepository : IB2CConsultaColecoesRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaColecoes> _linxMicrovixRepositoryBase;

        public B2CConsultaColecoesRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaColecoes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaColecoes> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaColecoes());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_colecao, records[i].nome_colecao, records[i].timestamp, records[i].marcas, records[i].portal);
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

        public async Task<List<B2CConsultaColecoes>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaColecoes> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_colecao}'";
                    else
                        identificadores += $"'{registros[i].codigo_colecao}', ";
                }

                string sql = $"SELECT CODIGO_COLECAO, TIMESTAMP FROM B2CCONSULTACOLECOES WHERE CODIGO_COLECAO IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaColecoes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_colecao], [nome_colecao], [timestamp], [marcas], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_colecao, @nome_colecao, @timestamp, @marcas, @portal)";

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
