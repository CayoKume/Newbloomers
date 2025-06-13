using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.IntegrationsCore.Entities.Auditing
{
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public EnumJob Job { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        public Int32? IdJob { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        public Guid? IdExecution { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public Guid? Execution { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        public Guid? ExecutionParent { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        public List<Record>? Records { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [SkipProperty]
        public List<Message>? Messages { get; private set; }

        public Log() { }

        /// <summary>
        /// Create a new log
        /// </summary>
        /// <param name="job"></param>
        public Log(EnumJob job)
        {
            Execution = Guid.NewGuid();
            Job = job;
            StartDate = DateTime.Now;
        }

        /// <summary>
        /// Set execution end date
        /// </summary>
        /// <param name="job"></param>
        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}
