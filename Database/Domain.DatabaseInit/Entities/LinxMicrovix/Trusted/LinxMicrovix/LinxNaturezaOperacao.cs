using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxNaturezaOperacao", Schema = "linx_microvix_erp")]
    public class LinxNaturezaOperacao
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "char(10)")]
        public string? cod_natureza_operacao { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? soma_relatorios { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? operacao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? inativa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public string? calcula_ipi { get; private set; }

        [Column(TypeName = "bit")]
        public string? calcula_iss { get; private set; }

        [Column(TypeName = "bit")]
        public string? calcula_irrf { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? tipo_preco { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? atualiza_custo { get; private set; }

        [Column(TypeName = "bit")]
        public string? transferencia { get; private set; }

        [Column(TypeName = "bit")]
        public string? baixar_estoque { get; private set; }

        [Column(TypeName = "bit")]
        public string? consumo_proprio { get; private set; }

        [Column(TypeName = "bit")]
        public string? contabiliza_cmv { get; private set; }

        [Column(TypeName = "bit")]
        public string? despesa { get; private set; }

        [Column(TypeName = "bit")]
        public string? atualiza_custo_medio { get; private set; }

        [Column(TypeName = "bit")]
        public string? exige_nf_origem { get; private set; }

        [Column(TypeName = "bit")]
        public string? integra_contabilidade { get; private set; }

        [Column(TypeName = "int")]
        public string? id_obs { get; private set; }

        [Column(TypeName = "bit")]
        public string? venda_futura { get; private set; }

        [Column(TypeName = "bit")]
        public string? base_icms_considera_ipi { get; private set; }

        [Column(TypeName = "bit")]
        public string? permite_escolha_historico { get; private set; }

        [Column(TypeName = "bit")]
        public string? import_produtos { get; private set; }

        [Column(TypeName = "int")]
        public string? deposito_reserva_venda { get; private set; }

        [Column(TypeName = "bit")]
        public string? exibe_nfe { get; private set; }

        [Column(TypeName = "bit")]
        public string? faturamento_antecipado { get; private set; }

        [Column(TypeName = "bit")]
        public string? exibir_informacoes_imposto { get; private set; }

        [Column(TypeName = "bit")]
        public string? gera_garantia_nacional { get; private set; }

        [Column(TypeName = "bit")]
        public string? transferencia_deposito { get; private set; }

        [Column(TypeName = "bit")]
        public string? venda_diferencial_aliquota { get; private set; }

        [Column(TypeName = "bit")]
        public string? insere_obs_pis_cofins { get; private set; }

        [Column(TypeName = "bit")]
        public string? diferencial_ativo_consumo { get; private set; }

        [Column(TypeName = "bit")]
        public string? recusa_de { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_ws { get; private set; }
    }
}
