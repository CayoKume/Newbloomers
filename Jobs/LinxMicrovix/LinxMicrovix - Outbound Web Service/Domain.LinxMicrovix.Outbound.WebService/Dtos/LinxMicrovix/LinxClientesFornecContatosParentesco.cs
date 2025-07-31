namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecContatosParentesco
    {
        public string? id_parentesco { get; set; }
        public string? descricao_parentesco { get; set; }
        public string? timestamp { get; set; }

        public LinxClientesFornecContatosParentesco()
        {
        }

        public LinxClientesFornecContatosParentesco(string? id_parentesco, string? descricao_parentesco, string? timestamp)
        {
            this.id_parentesco = id_parentesco;
            this.descricao_parentesco = descricao_parentesco;
            this.timestamp = timestamp;
        }
    }
}
