namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxProdutosDepositosCommandHandler
    {
        string CreateGetRegistersExistsQuery();
        string CreateInsertRecordQuery(string tableName);
    }
}
