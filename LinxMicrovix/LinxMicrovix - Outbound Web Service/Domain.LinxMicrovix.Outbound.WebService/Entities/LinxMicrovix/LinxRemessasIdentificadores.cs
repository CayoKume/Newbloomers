using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxRemessasIdentificadores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_venda { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_remessa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_remessas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_remessas_acertos { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_acerto { get; private set; }

        [Column(TypeName = "int")]
        public decimal? qtde_total_acerto { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_devolucao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_remessa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_remessa_operacoes { get; private set; }

        public LinxRemessasIdentificadores() { }

        public LinxRemessasIdentificadores(
            List<ValidationResult> listValidations,
            string identificador_venda,
            string identificador_remessa,
            string id_remessas,
            string id_remessas_acertos,
            string transacao_acerto,
            string qtde_total_acerto,
            string identificador_devolucao,
            string transacao_remessa,
            string id_remessa_operacoes
        )
        {
            lastupdateon = DateTime.Now;

            this.id_remessas =
                ConvertToInt32Validation.IsValid(id_remessas, "id_remessas", listValidations) ?
                Convert.ToInt32(id_remessas) :
                0;

            this.id_remessas_acertos =
                ConvertToInt32Validation.IsValid(id_remessas_acertos, "id_remessas_acertos", listValidations) ?
                Convert.ToInt32(id_remessas_acertos) :
                0;

            this.transacao_acerto =
                ConvertToInt32Validation.IsValid(transacao_acerto, "transacao_acerto", listValidations) ?
                Convert.ToInt32(transacao_acerto) :
                0;

            this.transacao_remessa =
                ConvertToInt32Validation.IsValid(transacao_remessa, "transacao_remessa", listValidations) ?
                Convert.ToInt32(transacao_remessa) :
                0;

            this.id_remessa_operacoes =
                ConvertToInt32Validation.IsValid(id_remessa_operacoes, "id_remessa_operacoes", listValidations) ?
                Convert.ToInt32(id_remessa_operacoes) :
                0;

            this.identificador_venda =
                String.IsNullOrEmpty(identificador_venda) ? null
                : Guid.Parse(identificador_venda);

            this.identificador_remessa =
                String.IsNullOrEmpty(identificador_remessa) ? null
                : Guid.Parse(identificador_remessa);

            this.identificador_devolucao =
                String.IsNullOrEmpty(identificador_devolucao) ? null
                : Guid.Parse(identificador_devolucao);

            this.qtde_total_acerto =
                ConvertToDecimalValidation.IsValid(qtde_total_acerto, "qtde_total_acerto", listValidations) ?
                Convert.ToDecimal(qtde_total_acerto) :
                0;
        }
    }
}
