using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoExtensao", Schema = "untreated")]
    public class LinxMovimentoExtensao
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_fcp_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_fcp_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_fcp_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_icms_fcp_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_icms_fcp_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_icms_fcp_st_retido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_icms_fcp_st_retido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_icms_fcp_st_antecipado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_icms_fcp_st_antecipado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_icms_fcp_st_antecipado { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? valor_iss { get; private set; }

        [Column(TypeName = "int")]
        public string? tipo_tributacao_iss { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_fcp_aliquota { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_fcp_base_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_fcp_valor_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_base_partilha { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_difal_interna_uf_destinatario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_difal_interestadual_uf_envolvidas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_item_perc_partilha_destino { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_item_perc_partilha_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigo_pacote { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigo_itens_associados { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigo_kit { get; private set; }

        [Column(TypeName = "int")]
        public string? id_motivo_desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_base_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_suportado_valor_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_suportado_valor_unitario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_pago_base { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_pago_valor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_pago_aliq { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_para_st_pago_valor { get; private set; }
    }
}
