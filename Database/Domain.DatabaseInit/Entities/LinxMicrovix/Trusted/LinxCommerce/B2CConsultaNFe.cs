using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaNFe", Schema = "linx_microvix_commerce")]
    public class B2CConsultaNFe
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_nfe { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pedido { get; private set; }

        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? data_emissao { get; private set; }

        [Key]
        [Column(TypeName = "char(44)")]
        public string? chave_nfe { get; private set; }

        [Column(TypeName = "tinyint")]
        public string? situacao { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? xml { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluido { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_microvix { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_insert { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_nota { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? frete { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? nProt { get; private set; }

        [Column(TypeName = "varchar(3)")]
        public string? codigo_modelo_nf { get; private set; }

        [Column(TypeName = "varchar(255)")]
        public string? justificativa { get; private set; }

        [Column(TypeName = "int")]
        public string? tpAmb { get; private set; }
    }
}
