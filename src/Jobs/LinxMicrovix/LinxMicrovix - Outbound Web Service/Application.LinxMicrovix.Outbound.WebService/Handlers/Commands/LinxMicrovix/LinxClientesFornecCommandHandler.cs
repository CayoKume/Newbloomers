using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class LinxClientesFornecCommandHandler : ILinxClientesFornecCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<string> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r}'"));
            return $"SELECT CONCAT('[', COD_CLIENTE, ']', '|', '[', DOC_CLIENTE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxClientesFornec] WHERE DOC_CLIENTE IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}]
                            ([lastupdateon],[portal],[cod_cliente],[razao_cliente],[nome_cliente],[doc_cliente],[tipo_cliente],[endereco_cliente],[numero_rua_cliente],[complement_end_cli],
                             [bairro_cliente],[cep_cliente],[cidade_cliente],[uf_cliente],[pais],[fone_cliente],[email_cliente],[sexo],[data_cadastro],[data_nascimento],[cel_cliente],[ativo],
                             [dt_update],[inscricao_estadual],[incricao_municipal],[identidade_cliente],[cartao_fidelidade],[cod_ibge_municipio],[classe_cliente],[matricula_conveniado],[tipo_cadastro],
                             [empresa_cadastro],[id_estado_civil],[fax_cliente],[site_cliente],[timestamp],[cliente_anonimo],[limite_compras],[codigo_ws],[limite_credito_compra],[id_classe_fiscal],[obs],
                             [mae])
                            Values
                            (@lastupdateon,@portal,@cod_cliente,@razao_cliente,@nome_cliente,@doc_cliente,@tipo_cliente,@endereco_cliente,@numero_rua_cliente,@complement_end_cli,@bairro_cliente,@cep_cliente,
                             @cidade_cliente,@uf_cliente,@pais,@fone_cliente,@email_cliente,@sexo,@data_cadastro,@data_nascimento,@cel_cliente,@ativo,@dt_update,@inscricao_estadual,@incricao_municipal,
                             @identidade_cliente,@cartao_fidelidade,@cod_ibge_municipio,@classe_cliente,@matricula_conveniado,@tipo_cadastro,@empresa_cadastro,@id_estado_civil,@fax_cliente,@site_cliente,
                             @timestamp,@cliente_anonimo,@limite_compras,@codigo_ws,@limite_credito_compra,@id_classe_fiscal,@obs,@mae)";
        }

        public string CreateIntegrityLockQuery()
        {
            return @$"select IIF(a.cpf is null, a.cnpj, a.cpf) as doc_cliente from linx_commerce.customer a (nolock)
                      left join linx_microvix_erp.LinxClientesFornec b (nolock) on IIF(a.cpf is null, a.cnpj, a.cpf) = b.doc_cliente
                      where b.doc_cliente is null and a.createddate > '2025-01-01'";
        }
    }
}
