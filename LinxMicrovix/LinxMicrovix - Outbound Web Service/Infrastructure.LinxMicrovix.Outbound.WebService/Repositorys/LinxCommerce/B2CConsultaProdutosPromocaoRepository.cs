﻿using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoRepository : IB2CConsultaProdutosPromocaoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosPromocao> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosPromocaoRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosPromocao> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosPromocao> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosPromocao());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigo_promocao, records[i].empresa, records[i].codigoproduto, records[i].preco, records[i].data_inicio, records[i].data_termino, records[i].data_cadastro,
                        records[i].ativa, records[i].codigo_campanha, records[i].promocao_opcional, records[i].timestamp, records[i].referencia, records[i].portal);
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

        public async Task<IEnumerable<B2CConsultaProdutosPromocao>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosPromocao> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].codigoproduto}'";
                    else
                        identificadores += $"'{registros[i].codigoproduto}', ";
                }

                string sql = $"SELECT CODIGOPRODUTO, TIMESTAMP FROM B2CCONSULTAPRODUTOSPROMOCAO WHERE CODIGOPRODUTO IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosPromocao? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [codigo_promocao], [empresa], [codigoproduto], [preco], [data_inicio], [data_termino], [data_cadastro], [ativa], [codigo_campanha], [promocao_opcional], [timestamp], [referencia], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @codigo_promocao, @empresa, @codigoproduto, @preco, @data_inicio, @data_termino, @data_cadastro, @ativa, @codigo_campanha, @promocao_opcional, @timestamp, @referencia, @portal)";

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
