using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaLinhasRepository : IB2CConsultaLinhasRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaLinhas> _linxMicrovixRepositoryBase;

        public B2CConsultaLinhasRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaLinhas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaLinhas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaLinhas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_linha, records[i].nome_linha, records[i].timestamp, records[i].setores, records[i].portal);
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

        public async Task<List<B2CConsultaLinhas>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaLinhas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_linha}'";
                    else
                        identificadores += $"'{registros[i].codigo_linha}', ";
                }

                string sql = $"SELECT CODIGO_LINHA, TIMESTAMP FROM B2CCONSULTALINHAS WHERE CODIGO_LINHA IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaLinhas? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_linha], [nome_linha], [timestamp], [setores], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_linha, @nome_linha, @timestamp, @setores, @portal)";

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
