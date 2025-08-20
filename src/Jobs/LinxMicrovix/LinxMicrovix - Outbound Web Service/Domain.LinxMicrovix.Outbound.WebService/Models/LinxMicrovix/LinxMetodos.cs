using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMetodos
    {
        [NotMapped]
        [SkipProperty]

        public DateTime? lastupdateon { get; private set; }

        public int? methodID { get; set; }

        public string? Retorno { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMetodos() { }

        public LinxMetodos(
            string? Retorno
        )
        {
            lastupdateon = DateTime.Now;
            this.Retorno = Retorno;
        }
    }
}
