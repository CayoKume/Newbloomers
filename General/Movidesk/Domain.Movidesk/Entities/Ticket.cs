namespace Domain.Movidesk.Entities
{
    public class Ticket
    {
        public Int32? id { get; set; }
        public Int32? type { get; set; }
        public Int32? origin { get; set; }
        public Int32? lifeTimeWorkingTime { get; set; }
        public Int32? stoppedTime { get; set; }
        public Int32? stoppedTimeWorkingTime { get; set; }
        public Int32? chatTalkTime { get; set; }
        public Int32? chatWaitingTime { get; set; }
        public Int32? sequence { get; set; }
        public Int32? slaSolutionTime { get; set; }
        public Int32? slaResponseTime { get; set; }
        public Int32? serviceFirstLevelId { get; set; }
        public Int32? actionCount { get; set; }

        public string? protocol { get; set; }
        public string? subject { get; set; }
        public string? category { get; set; }
        public string? urgency { get; set; }
        public string? status { get; set; }
        public string? baseStatus { get; set; }
        public string? justification { get; set; }
        public string? serviceFirstLevel { get; set; }
        public string? serviceSecondLevel { get; set; }
        public string? serviceThirdLevel { get; set; }
        public string? contactForm { get; set; }
        public string? cc { get; set; }
        public string? originEmailAccount { get; set; }
        public string? chatWidget { get; set; }
        public string? chatGroup { get; set; }
        public string? slaAgreement { get; set; }
        public string? slaAgreementRule { get; set; }
        public string? ownerTeam { get; set; }

        public List<string>? serviceFull { get; set; }
        public List<string>? tags { get; set; }

        public DateTime? slaSolutionDate { get; set; }
        public DateTime? slaResponseDate { get; set; }
        public DateTime? slaRealResponseDate { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? resolvedIn { get; set; }
        public DateTime? reopenedIn { get; set; }
        public DateTime? closedIn { get; set; }
        public DateTime? lastActionDate { get; set; }
        public DateTime? lastUpdate { get; set; }

        public bool? slaSolutionChangedByUser { get; set; }
        public bool? resolvedInFirstCall { get; set; }
        public bool? slaSolutionDateIsPaused { get; set; }

        public List<Action>? actions { get; set; }

        public PersonTicket? owner { get; set; }
        public PersonTicket? createdBy { get; set; }
        public PersonTicket? slaSolutionChangedBy { get; set; }
        public List<PersonTicket>? clients { get; set; }
    }
}
