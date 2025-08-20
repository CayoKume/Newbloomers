using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Base
{
    public abstract class ParameterBase
    {
        [NotMapped]
        public string? docMainCompany { get; private set; }

        [NotMapped]
        public string? projectName { get; private set; }

        [NotMapped]
        public string? keyAuthorization { get; private set; }

        [NotMapped]
        public string? userAuthentication { get; private set; }

        [NotMapped]
        public string? parametersTableName { get; private set; }

        protected ParameterBase(
            string? docMainCompany,
            string? projectName,
            string? keyAuthorization,
            string? userAuthentication,
            string? parametersTableName
        )
        {
            this.projectName = projectName;
            this.keyAuthorization = keyAuthorization;
            this.userAuthentication = userAuthentication;
            this.parametersTableName = parametersTableName;
            this.docMainCompany = docMainCompany;
        }
    }
}
