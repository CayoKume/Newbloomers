using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesCommandHandler : IB2CConsultaProdutosDetalhesCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosDetalhes> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_prod_det}'"));
            return $"SELECT CONCAT('[', ID_PROD_DET, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSDETALHES] WHERE ID_PROD_DET IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_prod_det], [codigoproduto], [empresa], [saldo], [controla_lote], [nomeproduto_alternativo], [timestamp], [referencia], [localizacao], [portal], [tempo_preparacao_estoque]) 
                          Values 
                          (@lastupdateon, @id_prod_det, @codigoproduto, @empresa, @saldo, @controla_lote, @nomeproduto_alternativo, @timestamp, @referencia, @localizacao, @portal, @tempo_preparacao_estoque)";
        }
    }
}
