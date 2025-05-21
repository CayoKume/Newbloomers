using Application.IntegrationsCore.Interfaces;

namespace Application.IntegrationsCore.Services
{
    public class SchemaConfigurable : ISchemaConfigurable
    {
        public string SetTrustedSchema(string schema)
        {
            return schema;
        }

        public string SetUnteatredSchema()
        {
            return "untreated";
        }
    }
}
