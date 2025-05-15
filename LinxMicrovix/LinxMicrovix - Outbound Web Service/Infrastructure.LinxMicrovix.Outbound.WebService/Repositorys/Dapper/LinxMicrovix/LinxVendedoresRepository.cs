using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxVendedoresRepository : ILinxVendedoresRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxVendedores> _linxMicrovixRepositoryBase;

        public LinxVendedoresRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxVendedores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxVendedores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxVendedores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_vendedor, records[i].nome_vendedor, records[i].tipo_vendedor, records[i].end_vend_rua, records[i].end_vend_numero,
                        records[i].end_vend_complemento, records[i].end_vend_bairro, records[i].end_vend_cep, records[i].end_vend_cidade, records[i].end_vend_uf, records[i].fone_vendedor,
                        records[i].mail_vendedor, records[i].dt_upd, records[i].cpf_vendedor, records[i].ativo, records[i].data_admissao, records[i].data_saida, records[i].portal, records[i].timestamp,
                        records[i].matricula, records[i].id_tipo_venda, records[i].descricao_tipo_venda, records[i].cargo);
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

        public async Task<List<string>> GetRegistersExists()
        {
            try
            {
                string sql = $"SELECT CONCAT('[', COD_VENDEDOR, ']', '|', '[', CPF_VENDEDOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxVendedores]";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxVendedores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [portal], [cod_vendedor], [nome_vendedor], [tipo_vendedor], [end_vend_rua], [end_vend_numero], [end_vend_complemento], [end_vend_bairro], [end_vend_cep], [end_vend_cidade], [end_vend_uf], [fone_vendedor], [mail_vendedor], [dt_upd], [cpf_vendedor], [ativo], [data_admissao], [data_saida], [timestamp], [matricula], [id_tipo_venda], [descricao_tipo_venda], [cargo]) " +
                          "Values " +
                          "(@lastupdateon, @portal, @cod_vendedor, @nome_vendedor, @tipo_vendedor, @end_vend_rua, @end_vend_numero, @end_vend_complemento, @end_vend_bairro, @end_vend_cep, @end_vend_cidade, @end_vend_uf, @fone_vendedor, @mail_vendedor, @dt_upd, @cpf_vendedor, @ativo, @data_admissao, @data_saida, @timestamp, @matricula, @id_tipo_venda, @descricao_tipo_venda, @cargo)";

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
