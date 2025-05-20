using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertos
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_remessas_acertos { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? id_remessas { get; private set; }

        public Guid? identificador_venda { get; private set; }

        public Guid? identificador_retorno { get; private set; }

        public Guid? identificador_devolucao { get; private set; }

        public DateTime? data { get; private set; }

        public Int64? id_vendas_pos { get; private set; }

        public bool? excluido { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoRemessasAcertos() { }

        public LinxMovimentoRemessasAcertos(
            List<ValidationResult> listValidations,
            string? id_remessas_acertos,
            string? portal,
            string? empresa,
            string? id_remessas,
            string? identificador_venda,
            string? identificador_retorno,
            string? identificador_devolucao,
            string? data,
            string? id_vendas_pos,
            string? excluido,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_remessas_acertos =
                ConvertToInt32Validation.IsValid(id_remessas_acertos, "id_remessas_acertos", listValidations) ?
                Convert.ToInt32(id_remessas_acertos) :
                0;

            this.id_remessas =
                ConvertToInt32Validation.IsValid(id_remessas, "id_remessas", listValidations) ?
                Convert.ToInt32(id_remessas) :
                0;

            this.identificador_venda =
                String.IsNullOrEmpty(identificador_venda) ? null
                : Guid.Parse(identificador_venda);

            this.identificador_retorno =
                String.IsNullOrEmpty(identificador_retorno) ? null
                : Guid.Parse(identificador_retorno);

            this.identificador_devolucao =
                String.IsNullOrEmpty(identificador_devolucao) ? null
                : Guid.Parse(identificador_devolucao);

            this.data =
               ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
               Convert.ToDateTime(data) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.excluido =
                ConvertToBooleanValidation.IsValid(excluido, "excluido", listValidations) ?
                Convert.ToBoolean(excluido) :
                false;

            this.id_vendas_pos =
                ConvertToInt64Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt64(id_vendas_pos) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
