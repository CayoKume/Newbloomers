
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxNaturezaOperacao
    {
        public DateTime? lastupdateon { get; private set; }
        public int? portal { get; private set; }
        public string? cod_natureza_operacao { get; private set; }
        public string? descricao { get; private set; }
        public string? soma_relatorios { get; private set; }
        public string? operacao { get; private set; }
        public string? inativa { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? calcula_ipi { get; private set; }
        public Int32? calcula_iss { get; private set; }
        public Int32? calcula_irrf { get; private set; }
        public string? tipo_preco { get; private set; }
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
        public string? codigo_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNaturezaOperacao() { }

        public LinxNaturezaOperacao(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNaturezaOperacao record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_obs = CustomConvertersExtensions.ConvertToInt32Validation(record.id_obs);
            this.deposito_reserva_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.deposito_reserva_venda);
            this.calcula_ipi = CustomConvertersExtensions.ConvertToInt32Validation(record.calcula_ipi);
            this.calcula_iss = CustomConvertersExtensions.ConvertToInt32Validation(record.calcula_iss);
            this.calcula_irrf = CustomConvertersExtensions.ConvertToInt32Validation(record.calcula_irrf);
            this.transferencia = CustomConvertersExtensions.ConvertToInt32Validation(record.transferencia);
            this.baixar_estoque = CustomConvertersExtensions.ConvertToInt32Validation(record.baixar_estoque);
            this.consumo_proprio = CustomConvertersExtensions.ConvertToBooleanValidation(record.consumo_proprio);
            this.contabiliza_cmv = CustomConvertersExtensions.ConvertToBooleanValidation(record.contabiliza_cmv);
            this.despesa = CustomConvertersExtensions.ConvertToBooleanValidation(record.despesa);
            this.atualiza_custo_medio = CustomConvertersExtensions.ConvertToBooleanValidation(record.atualiza_custo_medio);
            this.exige_nf_origem = CustomConvertersExtensions.ConvertToBooleanValidation(record.exige_nf_origem);
            this.integra_contabilidade = CustomConvertersExtensions.ConvertToInt32Validation(record.integra_contabilidade);
            this.venda_futura = CustomConvertersExtensions.ConvertToBooleanValidation(record.venda_futura);
            this.base_icms_considera_ipi = CustomConvertersExtensions.ConvertToBooleanValidation(record.base_icms_considera_ipi);
            this.permite_escolha_historico = CustomConvertersExtensions.ConvertToBooleanValidation(record.permite_escolha_historico);
            this.import_produtos = CustomConvertersExtensions.ConvertToBooleanValidation(record.import_produtos);
            this.exibe_nfe = CustomConvertersExtensions.ConvertToBooleanValidation(record.exibe_nfe);
            this.faturamento_antecipado = CustomConvertersExtensions.ConvertToBooleanValidation(record.faturamento_antecipado);
            this.exibir_informacoes_imposto = CustomConvertersExtensions.ConvertToBooleanValidation(record.exibir_informacoes_imposto);
            this.gera_garantia_nacional = CustomConvertersExtensions.ConvertToBooleanValidation(record.gera_garantia_nacional);
            this.transferencia_deposito = CustomConvertersExtensions.ConvertToBooleanValidation(record.transferencia_deposito);
            this.venda_diferencial_aliquota = CustomConvertersExtensions.ConvertToBooleanValidation(record.venda_diferencial_aliquota);
            this.insere_obs_pis_cofins = CustomConvertersExtensions.ConvertToBooleanValidation(record.insere_obs_pis_cofins);
            this.diferencial_ativo_consumo = CustomConvertersExtensions.ConvertToBooleanValidation(record.diferencial_ativo_consumo);
            this.recusa_de = CustomConvertersExtensions.ConvertToBooleanValidation(record.recusa_de);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo_ws = record.codigo_ws;
            this.atualiza_custo = record.atualiza_custo;
            this.tipo_preco = record.tipo_preco;
            this.inativa = record.inativa;
            this.operacao = record.operacao;
            this.soma_relatorios = record.soma_relatorios;
            this.descricao = record.descricao;
            this.cod_natureza_operacao = record.cod_natureza_operacao;
            this.recordKey = $"[{record.cod_natureza_operacao.Trim()}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
