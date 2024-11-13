using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaProdutosTabelas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tabela { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_tabela { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosTabelas() { }

        public B2CConsultaProdutosTabelas(
            string? id_tabela,
            string? nome_tabela,
            string? ativa,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tabela =
               String.IsNullOrEmpty(id_tabela) ? 0
               : Convert.ToInt32(id_tabela);

            this.nome_tabela =
               String.IsNullOrEmpty(nome_tabela) ? ""
               : nome_tabela.Substring(
                   0,
                   nome_tabela.Length > 50 ? 50
                   : nome_tabela.Length
               );

            this.ativa =
                String.IsNullOrEmpty(ativa) ? ""
                : ativa.Substring(
                    0,
                    ativa.Length > 1 ? 1
                    : ativa.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
