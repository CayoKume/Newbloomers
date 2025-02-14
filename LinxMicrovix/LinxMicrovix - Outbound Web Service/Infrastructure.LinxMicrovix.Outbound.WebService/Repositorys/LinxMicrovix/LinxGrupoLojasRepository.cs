using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxGrupoLojasRepository : ILinxGrupoLojasRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxGrupoLojas> _linxMicrovixRepositoryBase;

        public LinxGrupoLojasRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxGrupoLojas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxGrupoLojas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxGrupoLojas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cnpj, records[i].nome_empresa, records[i].id_empresas_rede, records[i].rede, records[i].portal,
                        records[i].nome_portal, records[i].empresa, records[i].classificacao_portal);
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

        public async Task<List<LinxGrupoLojas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxGrupoLojas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].empresa}'";
                    else
                        identificadores += $"'{registros[i].empresa}', ";
                }

                string sql = $"SELECT empresa FROM [linx_microvix_erp].[LinxGrupoLojas] WHERE empresa IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxGrupoLojas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[cnpj],[nome_empresa],[id_empresas_rede],[rede],[portal],[nome_portal],[empresa],[classificacao_portal])
                            Values
                            (@lastupdateon,@cnpj,@nome_empresa,@id_empresas_rede,@rede,@portal,@nome_portal,@empresa,@classificacao_portal)";

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