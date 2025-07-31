namespace Domain.Core.Entities.Auditing
{
    public class MessageLevel
    {
        public Int32? IdLogLevel { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public string? EnumLevelName { get; private set; }

        public MessageLevel() { }

        public MessageLevel(Int32? IdLogLevel, string? Title, string? Description, string? EnumLevelName)
        {
            this.IdLogLevel = IdLogLevel;
            this.Title = Title;
            this.Description = Description;
            this.EnumLevelName = EnumLevelName;
        }
    }
}
