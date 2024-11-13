using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? b2c { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosStatus() { }

        public B2CConsultaProdutosStatus(
            string? codigoproduto,
            string? referencia,
            string? ativo,
            string? b2c,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
               String.IsNullOrEmpty(codigoproduto) ? 0
               : Convert.ToInt64(codigoproduto);

            this.referencia =
                String.IsNullOrEmpty(referencia) ? ""
                : referencia.Substring(
                    0,
                    referencia.Length > 20 ? 20
                    : referencia.Length
                );

            this.ativo =
               String.IsNullOrEmpty(ativo) ? 0
               : Convert.ToInt32(ativo);

            this.b2c =
               String.IsNullOrEmpty(b2c) ? 0
               : Convert.ToInt32(b2c);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
