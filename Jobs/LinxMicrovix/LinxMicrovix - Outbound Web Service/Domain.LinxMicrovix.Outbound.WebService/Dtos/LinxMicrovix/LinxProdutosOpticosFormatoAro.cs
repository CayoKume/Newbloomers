

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosOpticosFormatoAro
    {
        public string? id_formato_aro { get; private set; }
        public string? codigo { get; private set; }
        public string? descricao { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosOpticosFormatoAro() { }

        public LinxProdutosOpticosFormatoAro(
            string? id_formato_aro,
            string? codigo,
            string? descricao,
            string? timestamp
        )
        {
            this.id_formato_aro = id_formato_aro;
            this.codigo = codigo;
            this.timestamp = timestamp;
            this.descricao = descricao;
        }
    }
}