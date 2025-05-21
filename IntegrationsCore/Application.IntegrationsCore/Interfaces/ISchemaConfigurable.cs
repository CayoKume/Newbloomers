namespace Application.IntegrationsCore.Interfaces
{
    public interface ISchemaConfigurable
    {
        string SetTrustedSchema(string schema);
        string SetUnteatredSchema();
    }
}
