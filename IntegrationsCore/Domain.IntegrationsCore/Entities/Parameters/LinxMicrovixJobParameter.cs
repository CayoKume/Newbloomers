namespace Domain.IntegrationsCore.Entities.Parameters
{
    public class LinxMicrovixJobParameter
    {
        public string? docDocMainCompany { get; private set; }
        public string? databaseName { get; private set; }
        public string? untreatedDatabaseName { get; private set; }
        public string? jobName { get; private set; }
        public string? projectName { get; private set; }
        public string? tableName { get; private set; }
        public string? keyAuthorization { get; private set; }
        public string? userAuthentication { get; private set; }
        public string? parametersInterval { get; private set; }
        public string? parametersTableName { get; private set; }

        /// <summary>
        /// Set parameters for any job
        /// </summary>
        /// <param name="docDocMainCompany"></param>
        /// <param name="databaseName"></param>
        /// <param name="untreatedDatabaseName"></param>
        /// <param name="projectName"></param>
        /// <param name="keyAuthorization"></param>
        /// <param name="userAuthentication"></param>
        /// <param name="parametersInterval"></param>
        /// <param name="parametersTableName"></param>
        public LinxMicrovixJobParameter(
            string? docDocMainCompany,
            string? databaseName,
            string? untreatedDatabaseName,
            string? projectName,
            string? keyAuthorization,
            string? userAuthentication,
            string? parametersInterval,
            string? parametersTableName
        )
        {
            this.docDocMainCompany = docDocMainCompany;
            this.databaseName = databaseName;
            this.untreatedDatabaseName = untreatedDatabaseName;
            this.projectName = projectName;
            this.keyAuthorization = keyAuthorization;
            this.userAuthentication = userAuthentication;
            this.parametersInterval = parametersInterval;
            this.parametersTableName = parametersTableName;
        }

        /// <summary>
        /// Set parameters for an specific job
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public LinxMicrovixJobParameter SetParameters(string? jobName, string? tableName)
        {
            this.jobName = jobName;
            this.tableName = tableName;

            return this;
        }
    }
}
