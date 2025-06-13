using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoPlanosRepository : ILinxMovimentoPlanosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxMovimentoPlanos> _linxMicrovixRepositoryBase;

        public LinxMovimentoPlanosRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxMovimentoPlanos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoPlanos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxMovimentoPlanos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].identificador, records[i].plano, records[i].desc_plano,
                        records[i].total, records[i].qtde_parcelas, records[i].indice_plano, records[i].cod_forma_pgto, records[i].forma_pgto, records[i].tipo_transacao,
                        records[i].taxa_financeira, records[i].ordem_cartao, records[i].timestamp, records[i].empresa);
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

        public async Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoPlanos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].identificador}'";
                    else
                        identificadores += $"'{registros[i].identificador}', ";
                }

                string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', PLANO, ']', '|', '[', IDENTIFICADOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxMovimentoPlanos] WHERE identificador IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoPlanos? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[portal],[cnpj_emp],[identificador],[plano],[desc_plano],[total],[qtde_parcelas],[indice_plano],[cod_forma_pgto],[forma_pgto],[tipo_transacao],
                             [taxa_financeira],[ordem_cartao],[timestamp],[empresa])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@identificador,@plano,@desc_plano,@total,@qtde_parcelas,@indice_plano,@cod_forma_pgto,@forma_pgto,@tipo_transacao,@taxa_financeira,
                             @ordem_cartao,@timestamp,@empresa)";

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
