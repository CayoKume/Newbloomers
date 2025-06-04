using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaPedidosPlanos", Schema = "untreated")]
    public class B2CConsultaPedidosPlanos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? id_pedido_planos { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pedido { get; private set; }

        [Column(TypeName = "int")]
        public string? plano_pagamento { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_plano { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? nsu_sitef { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? cod_autorizacao { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? texto_comprovante { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? cod_loja_sitef { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
