using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoPrincipal
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_movimento_principal { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto_manutencao { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_pergunta_venda { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_resposta_venda { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_fidelidade_cashback { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? plano_fidelidade_cashback { get; private set; }
        
        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "remessa_pedido_compra")]
        public string? remessa_pedido_compra { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_motivo_desconto { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_nota { get; private set; }

        public LinxMovimentoPrincipal() { }

        public LinxMovimentoPrincipal(
            List<ValidationResult> listValidations,
            string? id_movimento_principal,
            string? identificador,
            string? codigoproduto_manutencao,
            string? timestamp,
            string? id_pergunta_venda,
            string? id_resposta_venda,
            string? total_fidelidade_cashback,
            string? plano_fidelidade_cashback,
            string? remessa_pedido_compra,
            string? id_motivo_desconto,
            string? valor_nota
        )
        {
            lastupdateon = DateTime.Now;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.total_fidelidade_cashback =
                ConvertToDecimalValidation.IsValid(total_fidelidade_cashback, "total_fidelidade_cashback", listValidations) ?
                Convert.ToDecimal(total_fidelidade_cashback) :
                0;

            this.valor_nota =
                ConvertToDecimalValidation.IsValid(valor_nota, "valor_nota", listValidations) ?
                Convert.ToDecimal(valor_nota) :
                0;

            this.id_movimento_principal =
                ConvertToInt32Validation.IsValid(id_movimento_principal, "id_movimento_principal", listValidations) ?
                Convert.ToInt32(id_movimento_principal) :
                0;

            this.id_pergunta_venda =
                ConvertToInt32Validation.IsValid(id_pergunta_venda, "id_pergunta_venda", listValidations) ?
                Convert.ToInt32(id_pergunta_venda) :
                0;

            this.id_resposta_venda =
                ConvertToInt32Validation.IsValid(id_resposta_venda, "id_resposta_venda", listValidations) ?
                Convert.ToInt32(id_resposta_venda) :
                0;

            this.plano_fidelidade_cashback =
                ConvertToInt32Validation.IsValid(plano_fidelidade_cashback, "plano_fidelidade_cashback", listValidations) ?
                Convert.ToInt32(plano_fidelidade_cashback) :
                0;

            this.id_motivo_desconto =
                ConvertToInt32Validation.IsValid(id_motivo_desconto, "id_motivo_desconto", listValidations) ?
                Convert.ToInt32(id_motivo_desconto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigoproduto_manutencao =
                ConvertToInt64Validation.IsValid(codigoproduto_manutencao, "codigoproduto_manutencao", listValidations) ?
                Convert.ToInt64(codigoproduto_manutencao) :
                0;

            this.remessa_pedido_compra = remessa_pedido_compra;
        }
    }
}
