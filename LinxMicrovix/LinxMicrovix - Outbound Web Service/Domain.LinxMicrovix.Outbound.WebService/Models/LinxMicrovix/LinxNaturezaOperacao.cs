using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxNaturezaOperacao
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public int? portal { get; private set; }

        [LengthValidation(length: 10, propertyName: "cod_natureza_operacao")]
        public string? cod_natureza_operacao { get; private set; }

        [LengthValidation(length: 60, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [LengthValidation(length: 1, propertyName: "soma_relatorios")]
        public string? soma_relatorios { get; private set; }

        [LengthValidation(length: 2, propertyName: "operacao")]
        public string? operacao { get; private set; }

        [LengthValidation(length: 1, propertyName: "inativa")]
        public string? inativa { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? calcula_ipi { get; private set; }

        public Int32? calcula_iss { get; private set; }

        public Int32? calcula_irrf { get; private set; }

        [LengthValidation(length: 2, propertyName: "tipo_preco")]
        public string? tipo_preco { get; private set; }

        [LengthValidation(length: 1, propertyName: "atualiza_custo")]
        public string? atualiza_custo { get; private set; }

        public Int32? transferencia { get; private set; }

        public Int32? baixar_estoque { get; private set; }

        public bool? consumo_proprio { get; private set; }

        public bool? contabiliza_cmv { get; private set; }

        public bool? despesa { get; private set; }

        public bool? atualiza_custo_medio { get; private set; }

        public bool? exige_nf_origem { get; private set; }

        public Int32? integra_contabilidade { get; private set; }

        public Int32? id_obs { get; private set; }

        public bool? venda_futura { get; private set; }

        public bool? base_icms_considera_ipi { get; private set; }

        public bool? permite_escolha_historico { get; private set; }

        public bool? import_produtos { get; private set; }

        public Int32? deposito_reserva_venda { get; private set; }

        public bool? exibe_nfe { get; private set; }

        public bool? faturamento_antecipado { get; private set; }

        public bool? exibir_informacoes_imposto { get; private set; }

        public bool? gera_garantia_nacional { get; private set; }

        public bool? transferencia_deposito { get; private set; }

        public bool? venda_diferencial_aliquota { get; private set; }

        public bool? insere_obs_pis_cofins { get; private set; }

        public bool? diferencial_ativo_consumo { get; private set; }

        public bool? recusa_de { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNaturezaOperacao() { }

        public LinxNaturezaOperacao(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_natureza_operacao,
            string? descricao,
            string? soma_relatorios,
            string? operacao,
            string? inativa,
            string? timestamp,
            string? calcula_ipi,
            string? calcula_iss,
            string? calcula_irrf,
            string? tipo_preco,
            string? atualiza_custo,
            string? transferencia,
            string? baixar_estoque,
            string? consumo_proprio,
            string? contabiliza_cmv,
            string? despesa,
            string? atualiza_custo_medio,
            string? exige_nf_origem,
            string? integra_contabilidade,
            string? id_obs,
            string? venda_futura,
            string? base_icms_considera_ipi,
            string? permite_escolha_historico,
            string? import_produtos,
            string? deposito_reserva_venda,
            string? exibe_nfe,
            string? faturamento_antecipado,
            string? exibir_informacoes_imposto,
            string? gera_garantia_nacional,
            string? transferencia_deposito,
            string? venda_diferencial_aliquota,
            string? insere_obs_pis_cofins,
            string? diferencial_ativo_consumo,
            string? recusa_de,
            string? codigo_ws,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_obs =
                ConvertToInt32Validation.IsValid(id_obs, "id_obs", listValidations) ?
                Convert.ToInt32(id_obs) :
                0;

            this.deposito_reserva_venda =
                ConvertToInt32Validation.IsValid(deposito_reserva_venda, "deposito_reserva_venda", listValidations) ?
                Convert.ToInt32(deposito_reserva_venda) :
                0;

            this.calcula_ipi =
                ConvertToInt32Validation.IsValid(calcula_ipi, "calcula_ipi", listValidations) ?
                Convert.ToInt32(calcula_ipi) :
                0;

            this.calcula_iss =
                ConvertToInt32Validation.IsValid(calcula_iss, "calcula_iss", listValidations) ?
                Convert.ToInt32(calcula_iss) :
                0;

            this.calcula_irrf =
                ConvertToInt32Validation.IsValid(calcula_irrf, "calcula_irrf", listValidations) ?
                Convert.ToInt32(calcula_irrf) :
                0;

            this.transferencia =
                ConvertToInt32Validation.IsValid(transferencia, "transferencia", listValidations) ?
                Convert.ToInt32(transferencia) :
                0;

            this.baixar_estoque =
                ConvertToInt32Validation.IsValid(baixar_estoque, "baixar_estoque", listValidations) ?
                Convert.ToInt32(baixar_estoque) :
                0;

            this.consumo_proprio =
                ConvertToBooleanValidation.IsValid(consumo_proprio, "consumo_proprio", listValidations) ?
                Convert.ToBoolean(consumo_proprio) :
                false;

            this.contabiliza_cmv =
                ConvertToBooleanValidation.IsValid(contabiliza_cmv, "contabiliza_cmv", listValidations) ?
                Convert.ToBoolean(contabiliza_cmv) :
                false;

            this.despesa =
                ConvertToBooleanValidation.IsValid(despesa, "despesa", listValidations) ?
                Convert.ToBoolean(despesa) :
                false;

            this.atualiza_custo_medio =
                ConvertToBooleanValidation.IsValid(atualiza_custo_medio, "atualiza_custo_medio", listValidations) ?
                Convert.ToBoolean(atualiza_custo_medio) :
                false;

            this.exige_nf_origem =
                ConvertToBooleanValidation.IsValid(exige_nf_origem, "exige_nf_origem", listValidations) ?
                Convert.ToBoolean(exige_nf_origem) :
                false;

            this.integra_contabilidade =
                ConvertToInt32Validation.IsValid(integra_contabilidade, "integra_contabilidade", listValidations) ?
                Convert.ToInt32(integra_contabilidade) :
                0;

            this.venda_futura =
                ConvertToBooleanValidation.IsValid(venda_futura, "venda_futura", listValidations) ?
                Convert.ToBoolean(venda_futura) :
                false;

            this.base_icms_considera_ipi =
                ConvertToBooleanValidation.IsValid(base_icms_considera_ipi, "base_icms_considera_ipi", listValidations) ?
                Convert.ToBoolean(base_icms_considera_ipi) :
                false;

            this.permite_escolha_historico =
                ConvertToBooleanValidation.IsValid(permite_escolha_historico, "permite_escolha_historico", listValidations) ?
                Convert.ToBoolean(permite_escolha_historico) :
                false;

            this.import_produtos =
                ConvertToBooleanValidation.IsValid(import_produtos, "import_produtos", listValidations) ?
                Convert.ToBoolean(import_produtos) :
                false;

            this.exibe_nfe =
                ConvertToBooleanValidation.IsValid(exibe_nfe, "exibe_nfe", listValidations) ?
                Convert.ToBoolean(exibe_nfe) :
                false;

            this.faturamento_antecipado =
                ConvertToBooleanValidation.IsValid(faturamento_antecipado, "faturamento_antecipado", listValidations) ?
                Convert.ToBoolean(faturamento_antecipado) :
                false;

            this.exibir_informacoes_imposto =
                ConvertToBooleanValidation.IsValid(exibir_informacoes_imposto, "exibir_informacoes_imposto", listValidations) ?
                Convert.ToBoolean(exibir_informacoes_imposto) :
                false;

            this.gera_garantia_nacional =
                ConvertToBooleanValidation.IsValid(gera_garantia_nacional, "gera_garantia_nacional", listValidations) ?
                Convert.ToBoolean(gera_garantia_nacional) :
                false;

            this.transferencia_deposito =
                ConvertToBooleanValidation.IsValid(transferencia_deposito, "transferencia_deposito", listValidations) ?
                Convert.ToBoolean(transferencia_deposito) :
                false;

            this.venda_diferencial_aliquota =
                ConvertToBooleanValidation.IsValid(venda_diferencial_aliquota, "venda_diferencial_aliquota", listValidations) ?
                Convert.ToBoolean(venda_diferencial_aliquota) :
                false;

            this.insere_obs_pis_cofins =
                ConvertToBooleanValidation.IsValid(insere_obs_pis_cofins, "insere_obs_pis_cofins", listValidations) ?
                Convert.ToBoolean(insere_obs_pis_cofins) :
                false;

            this.diferencial_ativo_consumo =
                ConvertToBooleanValidation.IsValid(diferencial_ativo_consumo, "diferencial_ativo_consumo", listValidations) ?
                Convert.ToBoolean(diferencial_ativo_consumo) :
                false;

            this.recusa_de =
                ConvertToBooleanValidation.IsValid(recusa_de, "recusa_de", listValidations) ?
                Convert.ToBoolean(recusa_de) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo_ws = codigo_ws;
            this.atualiza_custo = atualiza_custo;
            this.tipo_preco = tipo_preco;
            this.inativa = inativa;
            this.operacao = operacao;
            this.soma_relatorios = soma_relatorios;
            this.descricao = descricao;
            this.cod_natureza_operacao = cod_natureza_operacao;
            this.recordKey = $"[{cod_natureza_operacao.Trim()}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
