namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxProdutosTabelasCommandHandler
    {
        string CreateGetRegistersExistsQuery();
        string CreateInsertRecordQuery(string tableName);
    }
}
