using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaPlanos", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPlanos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? nome_plano { get; private set; }

        [Column(TypeName = "int")]
        public string? forma_pagamento { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_parcelas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_minimo_parcela { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? indice { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? desativado { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_plano { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
