namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxClientesRede
    {
        public string? id_clientes_rede { get; set; }
        public string? doc_cliente { get; set; }
        public string? nome_razao_social { get; set; }
        public string? data_cadastro { get; set; }
        public string? pf_pj { get; set; }
        public string? tipo { get; set; }
        public string? endereco { get; set; }
        public string? cidade { get; set; }
        public string? uf { get; set; }
        public string? pais { get; set; }
        public string? id_estado_civil { get; set; }
        public string? compras_a_prazo { get; set; }
        public string? aceita_boleto_bancario { get; set; }
        public string? nome_fantasia { get; set; }
        public string? numero_endereco { get; set; }
        public string? complemento { get; set; }
        public string? bairro { get; set; }
        public string? cep { get; set; }
        public string? telefone { get; set; }
        public string? celular { get; set; }
        public string? fax { get; set; }
        public string? email { get; set; }
        public string? site { get; set; }
        public string? data_nascimento { get; set; }
        public string? naturalidade { get; set; }
        public string? sexo { get; set; }
        public string? nome_pai { get; set; }
        public string? nome_mae { get; set; }
        public string? identidade_cliente { get; set; }
        public string? data_emissao_identidade_cliente { get; set; }
        public string? uf_emissao_identidade_cliente { get; set; }
        public string? orgao_emissao_identidade_cliente { get; set; }
        public string? observacao { get; set; }
        public string? nome_empresa_titular { get; set; }
        public string? telefone_empresa_titular { get; set; }
        public string? funcao_titular { get; set; }
        public string? tempo_servico_titular { get; set; }
        public string? renda_titular { get; set; }
        public string? inscricao_estadual { get; set; }
        public string? inscricao_municipal { get; set; }
        public string? cliente_optante_simples_municipal { get; set; }
        public string? cliente_optante_simples_federal { get; set; }
        public string? limite_compras { get; set; }
        public string? cartao_fidelidade { get; set; }
        public string? desabilitado { get; set; }
        public string? motivo_bloqueio { get; set; }
        public string? portal_origem { get; set; }
        public string? empresa_origem { get; set; }
        public string? cod_cliente_portal_origem { get; set; }
        public string? codigo_ws { get; set; }
        public string? integrado_ws { get; set; }
        public string? timestamp { get; set; }
    }
}
