namespace IntegrationsCore.Domain.Exceptions
{
    public class APIErrorsExceptions
    {
        public class APIErrorException : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? response { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? api_error_message { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Response: {response}\n" +
                                              $"Description: Error getting record from api\n" +
                                              $"Message: {message}\n" +
                                              $"API Error Message: {api_error_message}\n" +
                                              $"Exception: {exception}";
        }

        public class APICallErrorException : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? endpoint { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Endpoint: {endpoint}\n" +
                                              $"Description: Error calling api\n" +
                                              $"Message: {message}\n" +
                                              $"Exception: {exception}";
        }
    }
}
