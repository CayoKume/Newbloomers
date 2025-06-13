namespace Domain.IntegrationsCore.Entities.Auditing
{
    public class Stage
    {
        public Int32? IdStage { get; private set; }
        public string? Method { get; private set; }
        public string? Description { get; private set; }
        public string? EnumStageName { get; private set; }

        public Stage() { }
    }
}
