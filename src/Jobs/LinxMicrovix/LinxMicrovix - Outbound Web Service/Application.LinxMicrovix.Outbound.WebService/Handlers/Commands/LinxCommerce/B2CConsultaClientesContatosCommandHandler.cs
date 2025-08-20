using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaClientesContatosCommandHandler : IB2CConsultaClientesContatosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaClientesContatos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_clientes_contatos}'"));
            return $"SELECT CONCAT('[', ID_CLIENTES_CONTATOS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESCONTATOS] WHERE ID_CLIENTES_CONTATOS IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_clientes_contatos], [id_contato_b2c], [nome_contato], [data_nasc_contato], [sexo_contato], 
                          [id_parentesco], [fone_contato], [celular_contato], [email_contato], [cod_cliente_erp], [timestamp], [portal])
                          Values 
                          (@lastupdateon, @id_clientes_contatos, @id_contato_b2c, @nome_contato, @data_nasc_contato, @sexo_contato, @id_parentesco, 
                          @fone_contato, @celular_contato, @email_contato, @cod_cliente_erp, @timestamp, @portal)";
        }
    }
}
