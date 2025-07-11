using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisaRepository : IB2CConsultaPalavrasChavePesquisaRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPalavrasChavePesquisa> _linxMicrovixRepositoryBase;

        public B2CConsultaPalavrasChavePesquisaRepository(ILinxMicrovixRepositoryBase<B2CConsultaPalavrasChavePesquisa> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPalavrasChavePesquisa> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPalavrasChavePesquisa());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].id_b2c_palavras_chave_pesquisa, records[i].nome_colecao, records[i].timestamp);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPalavrasChavePesquisa> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa}'";
                else
                    identificadores += $"'{registros[i].id_b2c_palavras_chave_pesquisa}', ";
            }

            string sql = $"SELECT CONCAT('[', ID_B2C_PALAVRAS_CHAVE_PESQUISA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPALAVRASCHAVEPESQUISA] WHERE ID_B2C_PALAVRAS_CHAVE_PESQUISA IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }
    }
}
