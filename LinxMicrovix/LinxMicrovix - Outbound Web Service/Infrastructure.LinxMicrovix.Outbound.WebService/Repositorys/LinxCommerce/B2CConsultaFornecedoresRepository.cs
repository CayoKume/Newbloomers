using Domain.IntegrationsCore.Entities.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaFornecedoresRepository : IB2CConsultaFornecedoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaFornecedores> _linxMicrovixRepositoryBase;

        public B2CConsultaFornecedoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaFornecedores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaFornecedores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaFornecedores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_fornecedor, records[i].nome, records[i].nome_fantasia, records[i].tipo_pessoa, records[i].tipo_fornecedor, records[i].endereco, records[i].numero_rua,
                        records[i].bairro, records[i].cep, records[i].cidade, records[i].uf, records[i].documento, records[i].fone, records[i].email, records[i].pais, records[i]. obs, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaFornecedores>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaFornecedores> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].documento}'";
                    else
                        identificadores += $"'{registros[i].documento}', ";
                }

                string sql = $"SELECT DOCUMENTO, TIMESTAMP FROM B2CCONSULTAFORNECEDORES WHERE DOCUMENTO IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaFornecedores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [cod_fornecedor], [nome], [nome_fantasia], [tipo_pessoa], [tipo_fornecedor], [endereco], [numero_rua], [bairro], [cep], [cidade], [uf], [documento], [fone], [email], [pais], [obs], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_fornecedor, @nome, @nome_fantasia, @tipo_pessoa, @tipo_fornecedor, @endereco, @numero_rua, @bairro, @cep, @cidade, @uf, @documento, @fone, @email, @pais, @obs, @timestamp, @portal)";

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
