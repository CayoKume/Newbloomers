using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaVendedoresRepository : IB2CConsultaVendedoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaVendedores> _linxMicrovixRepositoryBase;

        public B2CConsultaVendedoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaVendedores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaVendedores> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaVendedores());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_vendedor, records[i].nome_vendedor, records[i].comissao_produtos, records[i].comissao_servicos, records[i].tipo, records[i].ativo, records[i].comissionado, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaVendedores> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].cod_vendedor}'";
                    else
                        identificadores += $"'{registros[i].cod_vendedor}', ";
                }

                string sql = $"SELECT COD_VENDEDOR, TIMESTAMP FROM B2CCONSULTAVENDEDORES WHERE COD_VENDEDOR IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaVendedores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [cod_vendedor], [nome_vendedor], [comissao_produtos], [comissao_servicos], [tipo], [ativo], [comissionado], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_vendedor, @nome_vendedor, @comissao_produtos, @comissao_servicos, @tipo, @ativo, @comissionado, @timestamp, @portal)";

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
