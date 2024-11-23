using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Entities.Errors
{
    public class Log
    {
        public Guid Execution { get; set; }

        public EnumJob Job { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Record> Records { get; set; } = new List<Record>();
        public List<Message> Messages { get; set; } = new List<Message> { };

        public Log() { }

        public Log (EnumJob job)
        {
            this.Execution = Guid.NewGuid();
            this.Job = job;
            this.StartDate = DateTime.Now;
        }
    }
}
