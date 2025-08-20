namespace Infrastructure.Core.Data.Schemas
{
    public static class SchemaContext
    {
        private static readonly Dictionary<Type, string> _schemas = new();

        /// <summary>
        /// Registra os schemas baseados nos namespaces das entidades.
        /// Isso é feito antes da construção final do modelo pelo EF Core.
        /// </summary>
        public static void RegisterSchema(Type type, string schema)
        {
            _schemas[type] = schema;
        }

        public static string GetSchema(Type type)
        {
            return _schemas.TryGetValue(type, out var schema) ? schema : "dbo";
        }
    }
}
