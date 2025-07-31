namespace Domain.Core.Entities.Auditing
{
    public class Job
    {
        public Int32? IdParent { get; private set; }
        public Int32? IdJob { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public Int32? IdType { get; private set; }
        public string? Info { get; private set; }
        public string? EnumJobName { get; private set; }

        public Job() { }

        public Job(Int32? IdParent, Int32? IdJob, string? Title, string? Description, Int32? IdType, string? Info, string? EnumJobName)
        {
            this.IdParent = IdParent;
            this.IdJob = IdJob;
            this.Title = Title;
            this.Description = Description;
            this.IdType = IdType;
            this.Info = Info;
            this.EnumJobName = EnumJobName;
        }
    }
}
