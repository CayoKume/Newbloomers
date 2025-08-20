using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPerguntaVenda
    {
        public string? id_pergunta_venda { get; private set; }
        public string? portal { get; private set; }
        public string? descricao_pergunta { get; private set; }
        public string? timestamp { get; private set; }

        public LinxPerguntaVenda() { }

        public LinxPerguntaVenda(
            string? id_pergunta_venda,
            string? descricao_pergunta,
            string? timestamp,
            string? portal
        )
        {
            this.id_pergunta_venda = id_pergunta_venda;
            this.descricao_pergunta = descricao_pergunta;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}