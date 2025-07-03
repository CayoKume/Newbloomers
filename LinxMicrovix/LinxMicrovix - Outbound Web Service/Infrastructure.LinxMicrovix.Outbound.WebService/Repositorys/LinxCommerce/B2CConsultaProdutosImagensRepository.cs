﻿using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosImagensRepository : IB2CConsultaProdutosImagensRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosImagens> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosImagensRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosImagens> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosImagens> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosImagens());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_imagem_produto, records[i].id_imagem, records[i].codigoproduto, records[i].timestamp, records[i].portal);
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

        public async Task<IEnumerable<B2CConsultaProdutosImagens>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosImagens> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_imagem}'";
                    else
                        identificadores += $"'{registros[i].id_imagem}', ";
                }

                string sql = $"SELECT ID_IMAGEM, TIMESTAMP FROM B2CCONSULTAPRODUTOSIMAGENS WHERE ID_IMAGEM IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosImagens? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_imagem_produto], [id_imagem], [codigoproduto], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_imagem_produto, @id_imagem, @codigoproduto, @timestamp, @portal)";

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
