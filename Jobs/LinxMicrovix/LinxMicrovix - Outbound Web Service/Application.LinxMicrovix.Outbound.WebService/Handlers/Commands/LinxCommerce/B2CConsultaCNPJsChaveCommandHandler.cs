using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaCNPJsChaveCommandHandler : IB2CConsultaCNPJsChaveCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaCNPJsChave> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_empresas_rede}'"));
            return $"SELECT CONCAT('[', ID_EMPRESAS_REDE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACNPJSCHAVE] WHERE ID_EMPRESAS_REDE IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [cnpj], [nome_empresa], [id_empresas_rede], [rede], [portal], [nome_portal], [empresa], [classificacao_portal], [b2c], [oms]) 
                          Values 
                          (@lastupdateon, @cnpj, @nome_empresa, @id_empresas_rede, @rede, @portal, @nome_portal, @empresa, @classificacao_portal, @b2c, @oms)";
        }
    }
}
