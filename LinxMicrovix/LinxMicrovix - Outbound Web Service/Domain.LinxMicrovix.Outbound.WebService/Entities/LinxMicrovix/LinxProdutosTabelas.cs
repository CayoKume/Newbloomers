using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutosTabelas", Schema = "linx_microvix_erp")]
    public class LinxProdutosTabelas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tabela { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_tabela")]
        public string? nome_tabela { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "ativa")]
        public string? ativa { get; private set; }

        [Column(TypeName = "int")]
        public Int64? timestamp { get; private set; }

        [Key]
        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_tabela")]
        public string? tipo_tabela { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        public LinxProdutosTabelas() { }

        public LinxProdutosTabelas(
            List<ValidationResult> listValidations,
            string? id_tabela,
            string? portal,
            string? cnpj_emp,
            string? nome_tabela,
            string? ativa,
            string? timestamp,
            string? tipo_tabela,
            string? codigo_integracao_ws
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tabela =
                ConvertToInt32Validation.IsValid(id_tabela, "id_tabela", listValidations) ?
                Convert.ToInt32(id_tabela) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.nome_tabela = nome_tabela;
            this.tipo_tabela = tipo_tabela;
            this.ativa = ativa;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
