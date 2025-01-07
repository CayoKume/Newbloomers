using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
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
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutosCampanhas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_campanha, records[i].nome_campanha, records[i].vigencia_inicio, records[i].vigencia_fim, records[i].observacao, records[i].ativo, records[i].timestamp, records[i].portal);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
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

        public async Task<List<B2CConsultaProdutosCampanhas>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCampanhas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_campanha}'";
                    else
                        identificadores += $"'{registros[i].codigo_campanha}', ";
                }

                string sql = $"SELECT CODIGO_CAMPANHA, TIMESTAMP FROM B2CCONSULTAPRODUTOSCAMPANHAS WHERE CODIGO_CAMPANHA IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCampanhas? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_campanha], [nome_campanha], [vigencia_inicio], [vigencia_fim], [observacao], [ativo], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_campanha, @nome_campanha, @vigencia_inicio, @vigencia_fim, @observacao, @ativo, @timestamp, @portal)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
