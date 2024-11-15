using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFrete
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_tipo_cobranca_frete { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaTiposCobrancaFrete() { }

        public B2CConsultaTiposCobrancaFrete(
            string? codigo_tipo_cobranca_frete,
            string? nome_tipo_cobranca_frete,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.nome_tipo_cobranca_frete =
                String.IsNullOrEmpty(nome_tipo_cobranca_frete) ? ""
                : nome_tipo_cobranca_frete.Substring(
                    0,
                    nome_tipo_cobranca_frete.Length > 60 ? 60
                    : nome_tipo_cobranca_frete.Length
                );

            this.codigo_tipo_cobranca_frete =
                String.IsNullOrEmpty(codigo_tipo_cobranca_frete) ? 0
                : Convert.ToInt32(codigo_tipo_cobranca_frete);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
