using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.LinxMicrovix
{
    public class LinxVendedoresRepository : ILinxVendedoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxVendedores> _linxMicrovixRepositoryBase;

        public LinxVendedoresRepository(ILinxMicrovixRepositoryBase<LinxVendedores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, List<LinxVendedores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxVendedores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_vendedor, records[i].nome_vendedor, records[i].tipo_vendedor, records[i].end_vend_rua, records[i].end_vend_numero,
                        records[i].end_vend_complemento, records[i].end_vend_bairro, records[i].end_vend_cep, records[i].end_vend_cidade, records[i].end_vend_uf, records[i].fone_vendedor,
                        records[i].mail_vendedor, records[i].dt_upd, records[i].cpf_vendedor, records[i].ativo, records[i].data_admissao, records[i].data_saida, records[i].portal, records[i].timestamp,
                        records[i].matricula, records[i].id_tipo_venda, records[i].descricao_tipo_venda, records[i].cargo);
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

        public Task<List<LinxVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxVendedores> registros)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxVendedores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [portal], [cod_vendedor], [nome_vendedor], [tipo_vendedor], [end_vend_rua], [end_vend_numero], [end_vend_complemento], [end_vend_bairro], [end_vend_cep], [end_vend_cidade], [end_vend_uf], [fone_vendedor], [mail_vendedor], [dt_upd], [cpf_vendedor], [ativo], [data_admissao], [data_saida], [timestamp], [matricula], [id_tipo_venda], [descricao_tipo_venda], [cargo]) " +
                          "Values " +
                          "(@lastupdateon, @portal, @cod_vendedor, @nome_vendedor, @tipo_vendedor, @end_vend_rua, @end_vend_numero, @end_vend_complemento, @end_vend_bairro, @end_vend_cep, @end_vend_cidade, @end_vend_uf, @fone_vendedor, @mail_vendedor, @dt_upd, @cpf_vendedor, @ativo, @data_admissao, @data_saida, @timestamp, @matricula, @id_tipo_venda, @descricao_tipo_venda, @cargo)";

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
