using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler : IB2CConsultaProdutosCamposAdicionaisDetalhesCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCamposAdicionaisDetalhes> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_campo_detalhe}'"));
            return $"SELECT CONCAT('[', ID_CAMPO_DETALHE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSCAMPOSADICIONAISDETALHES] WHERE ID_CAMPO_DETALHE IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_campo_detalhe], [ordem], [descricao], [id_campo], [ativo], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_campo_detalhe, @ordem, @descricao, @id_campo, @ativo, @timestamp, @portal)";
        }
    }
}
