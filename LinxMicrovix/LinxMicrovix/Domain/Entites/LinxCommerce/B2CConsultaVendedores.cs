using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaVendedores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_vendedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comissao_produtos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comissao_servicos { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? comissionado { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaVendedores() { }

        public B2CConsultaVendedores(
            string? cod_vendedor,
            string? nome_vendedor,
            string? comissao_produtos,
            string? comissao_servicos,
            string? tipo,
            string? ativo,
            string? comissionado,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_vendedor =
                String.IsNullOrEmpty(cod_vendedor) ? 0
                : Convert.ToInt32(cod_vendedor);

            this.nome_vendedor =
                String.IsNullOrEmpty(nome_vendedor) ? ""
                : nome_vendedor.Substring(
                    0,
                    nome_vendedor.Length > 50 ? 50
                    : nome_vendedor.Length
                );

            this.comissao_produtos =
                String.IsNullOrEmpty(comissao_produtos) ? 0
                : Convert.ToDecimal(comissao_produtos);

            this.comissao_servicos =
                String.IsNullOrEmpty(comissao_servicos) ? 0
                : Convert.ToDecimal(comissao_servicos);

            this.tipo =
                String.IsNullOrEmpty(tipo) ? ""
                : tipo.Substring(
                    0,
                    tipo.Length > 1 ? 1
                    : tipo.Length
                );

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.comissionado =
                String.IsNullOrEmpty(comissionado) ? 0
                : Convert.ToInt32(comissionado);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
