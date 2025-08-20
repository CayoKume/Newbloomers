

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOticoPrismaDescricao
    {
        public string? id_otico_prisma_descricao { get; private set; }
        public string? descricao { get; private set; }
        public string? portal { get; private set; }
        public string? timestamp { get; private set; }

        public LinxOticoPrismaDescricao() { }

        public LinxOticoPrismaDescricao(
            string? id_otico_prisma_descricao,
            string? descricao,
            string? timestamp,
            string? portal
        )
        {
            this.id_otico_prisma_descricao = id_otico_prisma_descricao;
            this.descricao = descricao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}