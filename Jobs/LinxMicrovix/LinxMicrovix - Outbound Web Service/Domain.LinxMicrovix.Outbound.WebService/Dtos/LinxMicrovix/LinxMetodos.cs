namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMetodos
    {
        public string? methodID { get; set; }
        public string? Retorno { get; set; }

        public LinxMetodos()
        {
        }

        public LinxMetodos(string? methodID, string? Retorno)
        {
            this.methodID = methodID;
            this.Retorno = Retorno;
        }
    }
}
