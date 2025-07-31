namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxB2CStatusCommandHandler
    {
        string CreateGetRegistersExistsQuery();
        string CreateInsertRecordQuery(string tableName);
    }
}
