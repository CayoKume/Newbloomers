using Domain.IntegrationsCore.Entities.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters
{
    public class LinxAPIParam : ParameterBase
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? methodID { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? method { get; set; }

        [Column(TypeName = "varchar(800)")]
        public string? parameters_timestamp { get; set; }

        [Column(TypeName = "varchar(800)")]
        public string? parameters_dateinterval { get; set; }

        [Column(TypeName = "varchar(800)")]
        public string? parameters_individual { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? last_execution { get; set; }

        [NotMapped]
        public string? databaseName { get; private set; }

        [NotMapped]
        public string? untreatedDatabaseName { get; private set; }

        [NotMapped]
        public string? jobName { get; private set; }

        [NotMapped]
        public string? tableName { get; private set; }

        [NotMapped]
        public string? parametersInterval { get; private set; }

        /// <summary>
        /// Set parameters for any job
        /// </summary>
        /// <param name="docMainCompany"></param>
        /// <param name="databaseName"></param>
        /// <param name="untreatedDatabaseName"></param>
        /// <param name="projectName"></param>
        /// <param name="keyAuthorization"></param>
        /// <param name="userAuthentication"></param>
        /// <param name="parametersInterval"></param>
        /// <param name="parametersTableName"></param>
        public LinxAPIParam(
            string? docMainCompany,
            string? databaseName,
            string? untreatedDatabaseName,
            string? projectName,
            string? keyAuthorization,
            string? userAuthentication,
            string? parametersInterval,
            string? parametersTableName
        ) : base(
            docMainCompany: docMainCompany,
            projectName: projectName,
            keyAuthorization: keyAuthorization,
            userAuthentication: userAuthentication,
            parametersTableName: parametersTableName
        )
        {
            this.databaseName = databaseName;
            this.untreatedDatabaseName = untreatedDatabaseName;
            this.parametersInterval = parametersInterval;
        }

        /// <summary>
        /// Set parameters for an specific job
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public LinxAPIParam SetParameters(string? jobName, string? tableName)
        {
            this.jobName = jobName;
            this.tableName = tableName;

            return this;
        }
    }
}
