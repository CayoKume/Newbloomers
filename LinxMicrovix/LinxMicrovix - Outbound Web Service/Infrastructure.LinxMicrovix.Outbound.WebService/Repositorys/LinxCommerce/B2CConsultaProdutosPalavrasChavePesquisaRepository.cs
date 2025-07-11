using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisaRepository : IB2CConsultaProdutosPalavrasChavePesquisaRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosPalavrasChavePesquisa> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosPalavrasChavePesquisaRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutosPalavrasChavePesquisa> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosPalavrasChavePesquisa> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaProdutosPalavrasChavePesquisa());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].id_b2c_palavras_chave_pesquisa_produtos, records[i].id_b2c_palavras_chave_pesquisa, records[i].codigoproduto, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosPalavrasChavePesquisa> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa_produtos}'";
                else
                    identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa_produtos}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CConsultaProdutosPalavrasChavePesquisa] WHERE ID_B2C_PALAVRAS_CHAVE_PESQUISA_PRODUTOS IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }
    }
}
