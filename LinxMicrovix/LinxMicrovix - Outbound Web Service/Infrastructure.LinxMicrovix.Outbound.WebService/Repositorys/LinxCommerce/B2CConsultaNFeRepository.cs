using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaNFeRepository : IB2CConsultaNFeRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaNFe> _linxMicrovixRepositoryBase;

        public B2CConsultaNFeRepository(ILinxMicrovixRepositoryBase<B2CConsultaNFe> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaNFe> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaNFe());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_nfe, records[i].id_pedido, records[i].documento, records[i].data_emissao, records[i].chave_nfe, records[i].situacao, records[i].xml,
                        records[i].excluido, records[i].identificador_microvix, records[i].dt_insert, records[i].valor_nota, records[i].serie, records[i].frete, records[i].timestamp, records[i].portal,
                        records[i].nProt, records[i].codigo_modelo_nf, records[i].justificativa, records[i].tpAmb);
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

        public async Task<List<B2CConsultaNFe>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaNFe> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_nfe}'";
                    else
                        identificadores += $"'{registros[i].id_nfe}', ";
                }

                string sql = $"SELECT ID_NFE, TIMESTAMP FROM B2CCONSULTANFE WHERE ID_NFE IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaNFe? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_nfe], [id_pedido], [documento], [data_emissao], [chave_nfe], [situacao], [xml], [excluido], [identificador_microvix], [dt_insert], [valor_nota], [serie], [frete], [timestamp], [portal], [nProt], [codigo_modelo_nf], [justificativa], [tpAmb]) " +
                          "Values " +
                          "(@lastupdateon, @id_nfe, @id_pedido, @documento, @data_emissao, @chave_nfe, @situacao, @xml, @excluido, @identificador_microvix, @dt_insert, @valor_nota, @serie, @frete, @timestamp, @portal, @nProt, @codigo_modelo_nf, @justificativa, @tpAmb)";

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
