using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaFornecedoresCommandHandler : IB2CConsultaFornecedoresCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaFornecedores> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.documento}'"));
            return $"SELECT CONCAT('[', DOCUMENTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAFORNECEDORES] WHERE DOCUMENTO IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [cod_fornecedor], [nome], [nome_fantasia], [tipo_pessoa], [tipo_fornecedor], [endereco], [numero_rua], [bairro], [cep], [cidade], [uf], [documento], [fone], [email], [pais], [obs], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @cod_fornecedor, @nome, @nome_fantasia, @tipo_pessoa, @tipo_fornecedor, @endereco, @numero_rua, @bairro, @cep, @cidade, @uf, @documento, @fone, @email, @pais, @obs, @timestamp, @portal)";
        }
    }
}
