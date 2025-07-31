using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosOpticosTipo
    {
        public string? id_produtos_opticos_tipo { get; private set; }
        public string? tipo { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosOpticosTipo() { }

        public LinxProdutosOpticosTipo(
            string? id_produtos_opticos_tipo,
            string? tipo,
            string? timestamp
        )
        {
            this.id_produtos_opticos_tipo = id_produtos_opticos_tipo;
            this.tipo = tipo;
            this.timestamp = timestamp;
        }
    }
}