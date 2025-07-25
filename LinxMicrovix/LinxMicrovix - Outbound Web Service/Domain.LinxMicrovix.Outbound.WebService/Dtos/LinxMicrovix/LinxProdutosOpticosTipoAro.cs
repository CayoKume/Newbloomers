using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosOpticosTipoAro
    {
        public string? id_tipo_aro { get; private set; }
        public string? tipo_aro { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosOpticosTipoAro() { }

        public LinxProdutosOpticosTipoAro(
            string? id_tipo_aro,
            string? tipo_aro,
            string? timestamp
        )
        {
            this.id_tipo_aro = id_tipo_aro;
            this.tipo_aro = tipo_aro;
            this.timestamp = timestamp;
        }
    }
}