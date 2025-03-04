using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Entities.Errors
{
    public class Log
    {
        public Guid Execution { get; private set; }

        public EnumJob Job { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public List<Record> Records { get; private set; } = new List<Record>();
        public List<Message> Messages { get; private set; } = new List<Message> { };

        public Log(){ }

        /// <summary>
        /// Create a new log
        /// </summary>
        /// <param name="job"></param>
        public Log(EnumJob job)
        {
            this.Execution = Guid.NewGuid();
            this.Job = job;
            this.StartDate = DateTime.Now;
        }

        /// <summary>
        /// Set execution end date
        /// </summary>
        /// <param name="job"></param>
        public void SetEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }
    }
}
