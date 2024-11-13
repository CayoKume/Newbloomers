namespace Domain.IntegrationsCore.Exceptions
{
    public class RepositorysExceptions
    {
        public class ObjectNotFoundExcpetion : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? schema { get; set; }
            public required string? command { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Description: Error getting record from: {schema}\n" +
                                              $"Message: {message}\n" +
                                              $"Command: {command}\n" +
                                              $"Exception: {exception}";
        }

        public class ObjectsNotFoundExcpetion : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? schema { get; set; }
            public required string? command { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Description: Error getting records from: {schema}\n" +
                                              $"Message: {message}\n" +
                                              $"Command: {command}\n" +
                                              $"Exception: {exception}";
        }

        public class ExecuteWithoutCommandException : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? schema { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Description: Error executing query \nOn: {schema}\n" +
                                              $"Message: {message}\n" +
                                              $"Exception: {exception}";
        }

        public class ExecuteCommandException : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? schema { get; set; }
            public required string? command { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Description: Error executing command: {command}\nOn: {schema}\n" +
                                              $"Message: {message}\n" +
                                              $"Exception: {exception}";
        }

        public class ExecuteCommandWithParametersException : Exception
        {
            public required string? project { get; set; }
            public required string? job { get; set; }
            public required string? method { get; set; }
            public required string? message { get; set; }
            public required string? schema { get; set; }
            public required string? command { get; set; }
            public required string? parameter { get; set; }
            public required string? exception { get; set; }

            public override string? Message => $"Project: {project}\n" +
                                              $"Job: {job}\n" +
                                              $"Method: {method}\n" +
                                              $"Description: Error executing command: {command}\nWith parameters: {parameter}\nOn: {schema}\n" +
                                              $"Message: {message}\n" +
                                              $"Exception: {exception}";
        }
    }
}
