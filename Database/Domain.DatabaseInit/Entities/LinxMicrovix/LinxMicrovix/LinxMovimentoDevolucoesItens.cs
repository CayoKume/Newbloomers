using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxMovimentoDevolucoesItens", Schema = "untreated")]
    public class LinxMovimentoDevolucoesItens
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_movimento_devolucoes_itens { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_venda { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_devolucao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_origem { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_devolucao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_devolvida { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxMovimentoDevolucoesItens() { }

        public LinxMovimentoDevolucoesItens(
            List<ValidationResult> listValidations,
            string? id_movimento_devolucoes_itens,
            string? portal,
            string? identificador_venda,
            string? cnpj_emp,
            string? identificador_devolucao,
            string? codigoproduto,
            string? transacao_origem,
            string? transacao_devolucao,
            string? qtde_devolvida,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_movimento_devolucoes_itens =
                ConvertToInt32Validation.IsValid(id_movimento_devolucoes_itens, "id_movimento_devolucoes_itens", listValidations) ?
                Convert.ToInt32(id_movimento_devolucoes_itens) :
                0;

            this.transacao_origem =
                ConvertToInt32Validation.IsValid(transacao_origem, "transacao_origem", listValidations) ?
                Convert.ToInt32(transacao_origem) :
                0;

            this.transacao_devolucao =
                ConvertToInt32Validation.IsValid(transacao_devolucao, "transacao_devolucao", listValidations) ?
                Convert.ToInt32(transacao_devolucao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.identificador_venda =
                String.IsNullOrEmpty(identificador_venda) ? null
                : Guid.Parse(identificador_venda);

            this.identificador_devolucao =
                String.IsNullOrEmpty(identificador_devolucao) ? null
                : Guid.Parse(identificador_devolucao);

            this.qtde_devolvida =
                ConvertToDecimalValidation.IsValid(qtde_devolvida, "qtde_devolvida", listValidations) ?
                Convert.ToDecimal(qtde_devolvida) :
                0;

            this.cnpj_emp = cnpj_emp;
        }
    }
}
