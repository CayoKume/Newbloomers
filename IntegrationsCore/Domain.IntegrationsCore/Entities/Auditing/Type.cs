namespace Domain.IntegrationsCore.Entities.Auditing
{
    public class Type
    {
        public Int32? IdType { get; private set; }
        public string? JobType { get; private set; }
        public string? Description { get; private set; }

        public Type() { }
    }
}
