using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxNfceEstacao
    {
        public string? id_nfce_estacao { get; private set; }
        public string? empresa { get; private set; }
        public string? descricao { get; private set; }
        public string? numero_pdv_tef { get; private set; }
        public string? ativo { get; private set; }
        public string? timestamp { get; private set; }

        public LinxNfceEstacao() { }

        public LinxNfceEstacao(
            string? id_nfce_estacao,
            string? empresa,
            string? descricao,
            string? numero_pdv_tef,
            string? ativo,
            string? timestamp
        )
        {
            this.id_nfce_estacao = id_nfce_estacao;
            this.empresa = empresa;
            this.descricao = descricao;
            this.numero_pdv_tef = numero_pdv_tef;
            this.ativo = ativo;
            this.timestamp = timestamp;
        }
    }
}