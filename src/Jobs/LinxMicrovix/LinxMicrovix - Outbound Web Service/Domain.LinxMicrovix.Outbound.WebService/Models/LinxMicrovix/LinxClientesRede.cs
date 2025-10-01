
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClientesRede
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_clientes_rede { get; private set; }
        public string? doc_cliente { get; private set; }
        public string? nome_razao_social { get; private set; }
        public DateTime? data_cadastro { get; private set; }
        public string? pf_pj { get; private set; }
        public string? tipo { get; private set; }
        public string? endereco { get; private set; }
        public string? cidade { get; private set; }
        public string? uf { get; private set; }
        public string? pais { get; private set; }
        public Int32? id_estado_civil { get; private set; }
        public bool? compras_a_prazo { get; private set; }
        public bool? aceita_boleto_bancario { get; private set; }
        public string? nome_fantasia { get; private set; }
        public string? numero_endereco { get; private set; }
        public string? complemento { get; private set; }
        public string? bairro { get; private set; }
        public string? cep { get; private set; }
        public string? telefone { get; private set; }
        public string? celular { get; private set; }
        public string? fax { get; private set; }
        public string? email { get; private set; }
        public string? site { get; private set; }
        public DateTime? data_nascimento { get; private set; }
        public string? naturalidade { get; private set; }
        public string? sexo { get; private set; }
        public string? nome_pai { get; private set; }
        public string? nome_mae { get; private set; }
        public string? identidade_cliente { get; private set; }
        public DateTime? data_emissao_identidade_cliente { get; private set; }
        public string? uf_emissao_identidade_cliente { get; private set; }
        public string? orgao_emissao_identidade_cliente { get; private set; }
        public string? observacao { get; private set; }
        public string? nome_empresa_titular { get; private set; }
        public string? telefone_empresa_titular { get; private set; }
        public string? funcao_titular { get; private set; }
        public string? tempo_servico_titular { get; private set; }
        public decimal? renda_titular { get; private set; }
        public string? inscricao_estadual { get; private set; }
        public string? inscricao_municipal { get; private set; }
        public bool? cliente_optante_simples_municipal { get; private set; }
        public bool? cliente_optante_simples_federal { get; private set; }
        public decimal? limite_compras { get; private set; }
        public string? cartao_fidelidade { get; private set; }
        public bool? desabilitado { get; private set; }
        public string? motivo_bloqueio { get; private set; }
        public Int32? portal_origem { get; private set; }
        public Int32? empresa_origem { get; private set; }
        public Int32? cod_cliente_portal_origem { get; private set; }
        public string? codigo_ws { get; private set; }
        public bool? integrado_ws { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesRede() { }

        public LinxClientesRede(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesRede record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_clientes_rede = CustomConvertersExtensions.ConvertToInt32Validation(record.id_clientes_rede);
            this.portal_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.portal_origem);
            this.empresa_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa_origem);
            this.cod_cliente_portal_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_portal_origem);
            this.data_cadastro =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_cadastro);
            this.data_nascimento =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_nascimento);
            this.data_emissao_identidade_cliente =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_emissao_identidade_cliente);
            this.integrado_ws = CustomConvertersExtensions.ConvertToBooleanValidation(record.integrado_ws);
            this.desabilitado = CustomConvertersExtensions.ConvertToBooleanValidation(record.desabilitado);
            this.cliente_optante_simples_federal = CustomConvertersExtensions.ConvertToBooleanValidation(record.cliente_optante_simples_federal);
            this.cliente_optante_simples_municipal = CustomConvertersExtensions.ConvertToBooleanValidation(record.cliente_optante_simples_municipal);
            this.aceita_boleto_bancario = CustomConvertersExtensions.ConvertToBooleanValidation(record.aceita_boleto_bancario);
            this.compras_a_prazo = CustomConvertersExtensions.ConvertToBooleanValidation(compras_a_prazo);
            this.limite_compras = CustomConvertersExtensions.ConvertToDecimalValidation(record.limite_compras);
            this.renda_titular = CustomConvertersExtensions.ConvertToDecimalValidation(record.renda_titular);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.doc_cliente = record.doc_cliente;
            this.nome_razao_social = record.nome_razao_social;
            this.pf_pj = record.pf_pj;
            this.tipo = record.tipo;
            this.endereco = record.endereco;
            this.cidade = record.cidade;
            this.uf = record.uf;
            this.pais = record.pais;
            this.nome_fantasia = record.nome_fantasia;
            this.numero_endereco = record.numero_endereco;
            this.complemento = record.complemento;
            this.bairro = record.bairro;
            this.cep = record.cep;
            this.telefone = record.telefone;
            this.celular = record.celular;
            this.fax = record.fax;
            this.email = record.email;
            this.site = record.site;
            this.naturalidade = record.naturalidade;
            this.sexo = record.sexo;
            this.nome_pai = record.nome_pai;
            this.nome_mae = record.nome_mae;
            this.identidade_cliente = record.identidade_cliente;
            this.uf_emissao_identidade_cliente = record.uf_emissao_identidade_cliente;
            this.orgao_emissao_identidade_cliente = record.orgao_emissao_identidade_cliente;
            this.observacao = record.observacao;
            this.nome_empresa_titular = record.nome_empresa_titular;
            this.telefone_empresa_titular = record.telefone_empresa_titular;
            this.funcao_titular = record.funcao_titular;
            this.tempo_servico_titular = record.tempo_servico_titular;
            this.inscricao_estadual = record.inscricao_estadual;
            this.inscricao_municipal = record.inscricao_municipal;
            this.cartao_fidelidade = record.cartao_fidelidade;
            this.motivo_bloqueio = record.motivo_bloqueio;
            this.codigo_ws = record.codigo_ws;
        }
    }
}
