namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaGrade1
    {
        public string? codigo_grade1 { get; private set; }
        public string? nome_grade1 { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaGrade1() { }

        public B2CConsultaGrade1(
            string? codigo_grade1,
            string? nome_grade1,
            string? timestamp,
            string? portal
        )
        {
            this.codigo_grade1 = codigo_grade1;
            this.nome_grade1 = nome_grade1;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}