using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxPlanosRepository : ILinxPlanosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxPlanos> _linxMicrovixRepositoryBase;

        public LinxPlanosRepository(ILinxMicrovixRepositoryBase<LinxPlanos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanos> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxPlanos());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].plano, records[i].desc_plano, records[i].qtde_parcelas, records[i].prazo_entre_parcelas,
                    records[i].tipo_plano, records[i].indice_plano, records[i].cod_forma_pgto, records[i].forma_pgto, records[i].conta_central, records[i].tipo_transacao,
                    records[i].taxa_financeira, records[i].dt_upd, records[i].desativado, records[i].usa_tef, records[i].timestamp);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i]}'";
                else
                    identificadores += $"'{registros[i]}', ";
            }

            string sql = $"SELECT CONCAT('[', PLANO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxPlanos] WHERE plano IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanos? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[plano],[desc_plano],[qtde_parcelas],[prazo_entre_parcelas],[tipo_plano],[indice_plano],[cod_forma_pgto],[forma_pgto],[conta_central],
                             [tipo_transacao],[taxa_financeira],[dt_upd],[desativado],[usa_tef],[timestamp])
                            Values
                            (@lastupdateon,@portal,@plano,@desc_plano,@qtde_parcelas,@prazo_entre_parcelas,@tipo_plano,@indice_plano,@cod_forma_pgto,@forma_pgto,@conta_central,@tipo_transacao,
                             @taxa_financeira,@dt_upd,@desativado,@usa_tef,@timestamp)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
