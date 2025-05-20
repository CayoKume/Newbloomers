using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Schema;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Schema
{
    public static class SchemaContext
    {
        private static readonly Dictionary<Type, string> _schemas = new();

        public static void RegisterSchema(Type type, string schema)
        {
            _schemas[type] = schema;
        }

        public static string GetSchema(Type type)
        {
            return _schemas.TryGetValue(type, out var schema) ? schema : "dbo";
        }

        public static void Clear() => _schemas.Clear();
    }
}
