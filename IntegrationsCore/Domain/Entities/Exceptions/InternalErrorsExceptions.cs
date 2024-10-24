namespace IntegrationsCore.Domain.Entities.Exceptions
{
    public static class InternalErrorsExceptions
    {
        public class InternalErrorException : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? record { get; set; }
            public required string? propertie { get; set; }
            public required string? exception { get; set; }

            public override string Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Description: Error when convert xml to list objects\n" +
                                              $"Message: {message}\n" +
                                              $"Record: {record}\n" +
                                              $"Propertie: {propertie}\n" +
                                              $"Exception: {exception}";
        }
    }
}
