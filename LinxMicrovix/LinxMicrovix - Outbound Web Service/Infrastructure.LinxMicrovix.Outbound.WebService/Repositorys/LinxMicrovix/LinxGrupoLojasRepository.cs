using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxGrupoLojasRepository : ILinxGrupoLojasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxGrupoLojas> _linxMicrovixRepositoryBase;

        public LinxGrupoLojasRepository(ILinxMicrovixRepositoryBase<LinxGrupoLojas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxGrupoLojas> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxGrupoLojas());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].cnpj, records[i].nome_empresa, records[i].id_empresas_rede, records[i].rede, records[i].portal,
                    records[i].nome_portal, records[i].empresa, records[i].classificacao_portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists()
        {
            string sql = $"SELECT CONCAT('[', CNPJ, ']', '|', '[', NOME_EMPRESA, ']', '|', '[', ID_EMPRESAS_REDE, ']', '|', '[', REDE, ']', '|', '[', PORTAL, ']', '|', '[', NOME_PORTAL, ']' , '|', '[', EMPRESA, ']', '|', '[', CLASSIFICACAO_PORTAL, ']') FROM [linx_microvix_erp].[LinxGrupoLojas]";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxGrupoLojas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[cnpj],[nome_empresa],[id_empresas_rede],[rede],[portal],[nome_portal],[empresa],[classificacao_portal])
                            Values
                            (@lastupdateon,@cnpj,@nome_empresa,@id_empresas_rede,@rede,@portal,@nome_portal,@empresa,@classificacao_portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}