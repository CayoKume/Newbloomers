using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_campo_detalhe { get; private set; }

        [Column(TypeName = "int")]
        public Int32? ordem { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_campo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisDetalhes() { }

        public B2CConsultaProdutosCamposAdicionaisDetalhes(
            string? id_campo_detalhe, 
            string? ordem, 
            string? descricao, 
            string? id_campo, 
            string? ativo, 
            string? timestamp, 
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_campo_detalhe =
                String.IsNullOrEmpty(id_campo_detalhe) ? 0
                : Convert.ToInt32(id_campo_detalhe);

            this.ordem =
                String.IsNullOrEmpty(ordem) ? 0
                : Convert.ToInt32(ordem);

            this.descricao =
                String.IsNullOrEmpty(descricao) ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 30 ? 30
                    : descricao.Length
                );

            this.id_campo =
                String.IsNullOrEmpty(id_campo) ? 0
                : Convert.ToInt32(id_campo);

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
