namespace Infrastructure.IntegrationsCore.Data.Extensions
{
    public static class ProviderColumnTypesExtensions
    {
        public static readonly Dictionary<string, Dictionary<string, string>> Mappings = new()
        {
            {
                "SqlServer", new Dictionary<string, string>
                {
                    { "bool", "bit" },
                    { "tinyint", "tinyint" },
                    { "uuid", "uniqueidentifier" },
                    { "varchar_max", "varchar(max)" },
                    { "datetime", "datetime" }
                }
            },
            {
                "PostgreSQL", new Dictionary<string, string>
                {
                    { "bool", "boolean" },
                    { "tinyint", "smallint" },
                    { "uuid", "uuid" },
                    { "varchar_max", "text" },
                    { "datetime", "timestamp without time zone" }
                }
            },
            {
                "MySql", new Dictionary<string, string>
                {
                    { "bool", "boolean" },
                    { "tinyint", "tinyint" },
                    { "uuid", "char(36)" },
                    { "varchar_max", "varchar(max)" },
                    { "datetime", "datetime" }
                }
            }
        };
    }
}
