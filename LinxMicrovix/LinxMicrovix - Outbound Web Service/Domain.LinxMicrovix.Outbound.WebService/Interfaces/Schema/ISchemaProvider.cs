namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Schema
{
    public interface ISchemaProvider
    {
        string GetSchemaFor(Type entityType);
    }
}
