﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosTabelasPrecosRepository : ILinxProdutosTabelasPrecosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosTabelasPrecos> _linxMicrovixRepositoryBase;

        public LinxProdutosTabelasPrecosRepository(ILinxMicrovixRepositoryBase<LinxProdutosTabelasPrecos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosTabelasPrecos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutosTabelasPrecos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].cod_produto, records[i].portal, records[i].cnpj_emp, records[i].id_tabela, records[i].precovenda, records[i].timestamp);
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

        public async Task<IEnumerable<string?>> GetProductsTablesIds(LinxAPIParam jobParameter)
        {
            try
            {
                string sql = $"SELECT distinct id_tabela FROM [linx_microvix_erp].[LinxProdutosTabelas] where ativa = 'S'";

                return await _linxMicrovixRepositoryBase.GetParameters(sql);
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

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i]}'";
                    else
                        identificadores += $"'{registros[i]}', ";
                }

                string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', COD_PRODUTO, ']', '|', '[', ID_TABELA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxProdutosTabelasPrecos] WHERE cod_produto IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosTabelasPrecos? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[cod_produto],[portal],[cnpj_emp],[id_tabela],[precovenda],[timestamp])
                            Values
                            (@lastupdateon,@cod_produto,@portal,@cnpj_emp,@id_tabela,@precovenda,@timestamp)";

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
