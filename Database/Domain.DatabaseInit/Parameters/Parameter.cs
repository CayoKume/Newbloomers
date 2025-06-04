namespace Domain.DatabaseInit.Parameters
{
    public class Parameter
    {
        public string? databaseName { get; private set; }
        public string? untreatedDatabaseName { get; private set; }
        public string? parametersTableName { get; private set; }

        public Parameter(
            string? databaseName,
            string? untreatedDatabaseName,
            string? parametersTableName
        )
        {
            this.databaseName = databaseName;
            this.untreatedDatabaseName = untreatedDatabaseName;
            this.parametersTableName = parametersTableName;
        }
    }
}
