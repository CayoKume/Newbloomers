using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaClientesContatosRepository : IB2CConsultaClientesContatosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaClientesContatos> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesContatosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaClientesContatos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClientesContatos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaClientesContatos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_clientes_contatos, records[i].id_contato_b2c, records[i].nome_contato, records[i].data_nasc_contato, records[i].sexo_contato,
                        records[i].id_parentesco, records[i].fone_contato, records[i].celular_contato, records[i].email_contato, records[i].cod_cliente_erp, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaClientesContatos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClientesContatos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_clientes_contatos}'";
                    else
                        identificadores += $"'{registros[i].id_clientes_contatos}', ";
                }

                string sql = $"SELECT ID_CLIENTES_CONTATOS, TIMESTAMP FROM B2CCONSULTACLIENTESCONTATOS WHERE ID_CLIENTES_CONTATOS IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClientesContatos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_clientes_contatos], [id_contato_b2c], [nome_contato], [data_nasc_contato], [sexo_contato], " +
                          "[id_parentesco], [fone_contato], [celular_contato], [email_contato], [cod_cliente_erp], [timestamp], [portal])" +
                          "Values " +
                          "(@lastupdateon, @id_clientes_contatos, @id_contato_b2c, @nome_contato, @data_nasc_contato, @sexo_contato, @id_parentesco, " +
                          "@fone_contato, @celular_contato, @email_contato, @cod_cliente_erp, @timestamp, @portal)";

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
