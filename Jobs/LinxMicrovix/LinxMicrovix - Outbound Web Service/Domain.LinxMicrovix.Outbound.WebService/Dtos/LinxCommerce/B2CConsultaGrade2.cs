namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaGrade2
    {
        public string? codigo_grade2 { get; private set; }
        public string? nome_grade2 { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaGrade2() { }

        public B2CConsultaGrade2(
            string? codigo_grade2,
            string? nome_grade2,
            string? timestamp,
            string? portal
        )
        {
            this.codigo_grade2 = codigo_grade2;
            this.nome_grade2 = nome_grade2;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}