using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxAntecipacoesFinanceiras", Schema = "linx_microvix_erp")]
    public class LinxAntecipacoesFinanceiras
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }

        [Column(TypeName = "int")]
        public string? numero_antecipacao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_antecipacao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? previsao_entrega { get; private set; }

        [Column(TypeName = "char(3)")]
        public string? dav_pv { get; private set; }

        [Column(TypeName = "int")]
        public string? numero_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? dav_remessa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_unitario_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_pago_antecipacao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? entregue { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public string? cancelado { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_antecipacoes_financeiras { get; private set; }

        [Column(TypeName = "int")]
        public string? id_antecipacoes_financeiras_detalhes { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos_produtos { get; private set; }
    }
}
