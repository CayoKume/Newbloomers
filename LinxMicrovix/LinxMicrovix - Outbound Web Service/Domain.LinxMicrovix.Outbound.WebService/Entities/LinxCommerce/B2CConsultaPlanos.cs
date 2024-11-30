using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaPlanos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "nome_plano")]
        public string? nome_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? forma_pagamento { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_parcelas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_minimo_parcela { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? indice { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "desativado")]
        public string? desativado { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_plano")]
        public string? tipo_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPlanos() { }

        public B2CConsultaPlanos(
            List<ValidationResult> listValidations,
            string? plano,
            string? nome_plano,
            string? forma_pagamento,
            string? qtde_parcelas,
            string? valor_minimo_parcela,
            string? indice,
            string? timestamp,
            string? desativado,
            string? tipo_plano,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.plano =
                String.IsNullOrEmpty(plano) ? 0
                : Convert.ToInt32(plano);

            this.nome_plano = nome_plano;
            this.desativado = desativado;
            this.tipo_plano = tipo_plano;

            this.forma_pagamento = 
                String.IsNullOrEmpty(forma_pagamento) ? 0
                : Convert.ToInt32(forma_pagamento);

            this.qtde_parcelas =
                String.IsNullOrEmpty(qtde_parcelas) ? 0
                : Convert.ToInt32(qtde_parcelas);

            this.valor_minimo_parcela =
                String.IsNullOrEmpty(valor_minimo_parcela) ? 0
                : Convert.ToDecimal(valor_minimo_parcela);

            this.indice =
                String.IsNullOrEmpty(indice) ? 0
                : Convert.ToDecimal(indice);


            this.portal =
                 ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                 Convert.ToInt32(portal) :
                 0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
