using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoTrocasRepository : ILinxMovimentoTrocasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxMovimentoTrocas> _linxMicrovixRepositoryBase;

        public LinxMovimentoTrocasRepository(ILinxMicrovixRepositoryBase<LinxMovimentoTrocas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoTrocas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxMovimentoTrocas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].identificador, records[i].num_vale, records[i].valor_vale,
                        records[i].motivo, records[i].doc_origem, records[i].serie_origem, records[i].doc_venda, records[i].serie_venda, records[i].excluido,
                        records[i].timestamp, records[i].desfazimento, records[i].empresa, records[i].vale_cod_cliente, records[i].vale_codigoproduto, records[i].id_vale_ordem_servico_externa, 
                        records[i].doc_venda_origem, records[i].serie_venda_origem, records[i].cod_cliente);
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

        public async Task<List<LinxMovimentoTrocas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocas> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].num_vale}'";
                    else
                        identificadores += $"'{registros[i].num_vale}', ";
                }

                string sql = $"SELECT cnpj_emp, num_vale, cod_cliente, TIMESTAMP FROM [linx_microvix_erp].[LinxMovimentoTrocas] WHERE num_vale IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[cnpj_emp],[identificador],[num_vale],[valor_vale],[motivo],[doc_origem],[serie_origem],[doc_venda],[serie_venda],[excluido]
                            ,[timestamp],[desfazimento],[empresa],[vale_cod_cliente],[vale_codigoproduto],[id_vale_ordem_servico_externa],[doc_venda_origem],[serie_venda_origem],[cod_cliente])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@identificador,@num_vale,@valor_vale,@motivo,@doc_origem,@serie_origem,@doc_venda,@serie_venda,@excluido,@timestamp,@desfazimento,
                             @empresa,@vale_cod_cliente,@vale_codigoproduto,@id_vale_ordem_servico_externa,@doc_venda_origem,@serie_venda_origem,@cod_cliente)";

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
