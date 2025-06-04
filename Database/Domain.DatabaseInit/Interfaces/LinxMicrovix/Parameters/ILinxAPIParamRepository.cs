namespace Domain.DatabaseInit.Interfaces.LinxMicrovix.Parameters
{
    public interface ILinxAPIParamRepository
    {
        public bool CreateTableIfNotExists(string databaseName, string jobName);
    }
}
