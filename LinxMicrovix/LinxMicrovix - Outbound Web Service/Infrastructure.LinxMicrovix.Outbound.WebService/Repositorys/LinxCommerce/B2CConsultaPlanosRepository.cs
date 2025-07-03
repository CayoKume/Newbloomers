using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPlanosRepository : IB2CConsultaPlanosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPlanos> _linxMicrovixRepositoryBase;

        public B2CConsultaPlanosRepository(ILinxMicrovixRepositoryBase<B2CConsultaPlanos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPlanos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPlanos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].plano, records[i].nome_plano, records[i].forma_pagamento, records[i].qtde_parcelas, records[i].valor_minimo_parcela, records[i].indice, records[i].timestamp,
                        records[i].desativado, records[i].tipo_plano, records[i].portal);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    dataTable: table
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<B2CConsultaPlanos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPlanos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].plano}'";
                    else
                        identificadores += $"'{registros[i].plano}', ";
                }

                string sql = $"SELECT PLANO, TIMESTAMP FROM B2CCONSULTAPLANOS WHERE PLANO IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(sql);
            }
            catch (Exception ex) when (ex is not GeneralException && ex is not SQLCommandException)
            {
                throw new GeneralException(
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPlanos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [plano], [nome_plano], [forma_pagamento], [qtde_parcelas], [valor_minimo_parcela], [indice], [timestamp], [desativado], [tipo_plano], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @plano, @nome_plano, @forma_pagamento, @qtde_parcelas, @valor_minimo_parcela, @indice, @timestamp, @desativado, @tipo_plano, @portal)";

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
