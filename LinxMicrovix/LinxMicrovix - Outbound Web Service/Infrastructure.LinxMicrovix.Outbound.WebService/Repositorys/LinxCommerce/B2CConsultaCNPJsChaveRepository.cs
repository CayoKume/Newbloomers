using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaCNPJsChaveRepository : IB2CConsultaCNPJsChaveRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaCNPJsChave> _linxMicrovixRepositoryBase;

        public B2CConsultaCNPJsChaveRepository(ILinxMicrovixRepositoryBase<B2CConsultaCNPJsChave> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaCNPJsChave> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaCNPJsChave());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].cnpj, records[i].nome_empresa, records[i].id_empresas_rede, records[i].rede, records[i].portal, records[i].nome_portal,
                    records[i].empresa, records[i].classificacao_portal, records[i].b2c, records[i].oms);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaCNPJsChave> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_empresas_rede}'";
                else
                    identificadores += $"'{registros[i].id_empresas_rede}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_EMPRESAS_REDE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACNPJSCHAVE] WHERE ID_EMPRESAS_REDE IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaCNPJsChave? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [cnpj], [nome_empresa], [id_empresas_rede], [rede], [portal], [nome_portal], [empresa], [classificacao_portal], [b2c], [oms]) " +
                          "Values " +
                          "(@lastupdateon, @cnpj, @nome_empresa, @id_empresas_rede, @rede, @portal, @nome_portal, @empresa, @classificacao_portal, @b2c, @oms)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
