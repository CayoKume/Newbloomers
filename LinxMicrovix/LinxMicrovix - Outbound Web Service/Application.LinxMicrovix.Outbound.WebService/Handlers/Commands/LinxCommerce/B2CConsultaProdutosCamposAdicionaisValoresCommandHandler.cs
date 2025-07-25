using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValoresCommandHandler : IB2CConsultaProdutosCamposAdicionaisValoresCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCamposAdicionaisValores> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_campo_valor}'"));
            return $"SELECT CONCAT('[', ID_CAMPO_VALOR, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTES] WHERE ID_CAMPO_VALOR IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_campo_valor], [codigoproduto], [id_campo_detalhe], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_campo_valor, @codigoproduto, @id_campo_detalhe, @timestamp, @portal)";
        }
    }
}
