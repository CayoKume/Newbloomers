using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaNFeCommandHandler : IB2CConsultaNFeCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<int?> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r}'"));
            return $"SELECT CONCAT('[', ID_NFE, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CHAVE_NFE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTANFE] WHERE ID_NFE IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}] 
                          ([lastupdateon], [id_nfe], [id_pedido], [documento], [data_emissao], [chave_nfe], [situacao], [xml], [excluido], [identificador_microvix], [dt_insert], [valor_nota], [serie], [frete], [timestamp], [portal], [nProt], [codigo_modelo_nf], [justificativa], [tpAmb]) 
                          Values 
                          (@lastupdateon, @id_nfe, @id_pedido, @documento, @data_emissao, @chave_nfe, @situacao, @xml, @excluido, @identificador_microvix, @dt_insert, @valor_nota, @serie, @frete, @timestamp, @portal, @nProt, @codigo_modelo_nf, @justificativa, @tpAmb)";
        }
    }
}
