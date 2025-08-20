

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxSeries
    {
        public string? portal { get; private set; }
        public string? serie { get; private set; }
        public string? id_modelo_nf { get; private set; }
        public string? timestamp { get; private set; }

        public LinxSeries() { }

        public LinxSeries(
            string? portal,
            string? serie,
            string? id_modelo_nf,
            string? timestamp
        )
        {
            this.id_modelo_nf = id_modelo_nf;
            this.serie = serie;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}