using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteRepository : IB2CConsultaTiposCobrancaFreteRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaTiposCobrancaFrete> _linxMicrovixRepositoryBase;

        public B2CConsultaTiposCobrancaFreteRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaTiposCobrancaFrete> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTiposCobrancaFrete> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaTiposCobrancaFrete());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_tipo_cobranca_frete, records[i].nome_tipo_cobranca_frete, records[i].timestamp, records[i].portal);
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

        public async Task<List<B2CConsultaTiposCobrancaFrete>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTiposCobrancaFrete> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigo_tipo_cobranca_frete}'";
                    else
                        identificadores += $"'{registros[i].codigo_tipo_cobranca_frete}', ";
                }

                string sql = $"SELECT CODIGO_TIPO_COBRANCA_FRETE, TIMESTAMP FROM B2CCONSULTATIPOSCOBRANCAFRETE WHERE CODIGO_TIPO_COBRANCA_FRETE IN ({identificadores})";

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
    }
}
