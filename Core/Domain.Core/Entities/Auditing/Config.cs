namespace Domain.Core.Entities.Auditing
{
    public class Config
    {
        public Int32? IdJobConfig { get; private set; }
        public Int32? IdJob { get; private set; }
        public Int32? MinutesInterval { get; private set; }
        public bool? IsActive { get; private set; }

        public Config() { }
    }
}
