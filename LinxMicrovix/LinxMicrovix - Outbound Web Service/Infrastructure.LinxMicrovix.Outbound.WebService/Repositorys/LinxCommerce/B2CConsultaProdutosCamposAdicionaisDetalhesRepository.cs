using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhesRepository : IB2CConsultaProdutosCamposAdicionaisDetalhesRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisDetalhes> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosCamposAdicionaisDetalhesRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosCamposAdicionaisDetalhes> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCamposAdicionaisDetalhes> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosCamposAdicionaisDetalhes());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_campo_detalhe, records[i].ordem, records[i].descricao, records[i].id_campo, records[i].ativo, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCamposAdicionaisDetalhes> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_campo_detalhe}'";
                else
                    identificadores += $"'{registros[i].id_campo_detalhe}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_CAMPO_DETALHE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES] WHERE ID_CAMPO_DETALHE IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCamposAdicionaisDetalhes? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [id_campo_detalhe], [ordem], [descricao], [id_campo], [ativo], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @id_campo_detalhe, @ordem, @descricao, @id_campo, @ativo, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
