namespace Domain.IntegrationsCore.Entities.Parameters
{
    public class LinxMicrovixJobParameter
    {
        public string? docMainCompany { get; set; }

        public string? jobName { get; set; }
        public string? projectName { get; set; }
        public string? tableName { get; set; }

        public string? keyAuthorization { get; set; }
        public string? userAuthentication { get; set; }

        public string? parametersInterval { get; set; }
        public string? parametersTableName { get; set; }
        public string? parametersLogTableName { get; set; }
    }
}
