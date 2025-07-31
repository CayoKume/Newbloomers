using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisaCommandHandler : IB2CConsultaPalavrasChavePesquisaCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaPalavrasChavePesquisa> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_b2c_palavras_chave_pesquisa}'"));
            return $"SELECT CONCAT('[', ID_B2C_PALAVRAS_CHAVE_PESQUISA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPALAVRASCHAVEPESQUISA] WHERE ID_B2C_PALAVRAS_CHAVE_PESQUISA IN ({identificadores})";
        }
    }
}
