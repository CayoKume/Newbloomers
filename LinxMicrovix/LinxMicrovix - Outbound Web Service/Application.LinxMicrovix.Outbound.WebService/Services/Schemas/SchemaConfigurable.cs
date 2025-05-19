using Application.LinxMicrovix.Outbound.WebService.Interfaces.Schemas;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Schemas
{
    public class SchemaConfigurable : ISchemaConfigurable
    {
        public string SetEcomSchema()
        {
            return "linx_microvix_commerce";
        }

        public string SetErpSchema()
        {
            return "linx_microvix_erp";
        }

        public string SetUnteatredSchema()
        {
            return "untreated";
        }
    }
}
