namespace Domain.Core.Entities.Auditing
{
    public class Error
    {
        public Int32? IdError { get; private set; }
        public string? _Error { get; private set; }
        public string? Resolution { get; private set; }
        public bool? RequireUserAction { get; private set; }
        public Int32? EmergencyLevel { get; private set; }
        public string? ActionInf { get; private set; }
        public string? EnumErrorName { get; private set; }

        public Error() { }

        public Error(Int32? IdError, string? _Error, string? Resolution, string? RequireUserAction, Int32? EmergencyLevel, string? ActionInf, string? EnumErrorName)
        {
            this.IdError = IdError;
            this._Error = _Error;
            this.Resolution = Resolution;
            this.RequireUserAction = RequireUserAction == "true" ? true : false;
            this.EmergencyLevel = EmergencyLevel;
            this.ActionInf = ActionInf;
            this.EnumErrorName = EnumErrorName;
        }
    }
}
