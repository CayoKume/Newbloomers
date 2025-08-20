namespace Domain.Movidesk.Models.Tickets
{
    public class Ticket
    {
        public int id { get; set; }
        public int type { get; set; }
        public int origin { get; set; }
        public int lifeTimeWorkingTime { get; set; }
        public int stoppedTime { get; set; }
        public int stoppedTimeWorkingTime { get; set; }
        public int chatTalkTime { get; set; }
        public int chatWaitingTime { get; set; }
        public int sequence { get; set; }
        public int slaSolutionTime { get; set; }
        public int slaResponseTime { get; set; }
        public int serviceFirstLevelId { get; set; }
        public int actionCount { get; set; }

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
        public string? serviceFull { get; set; }
        public string? tags { get; set; }

        public DateTime slaSolutionDate { get; set; }
        public DateTime slaResponseDate { get; set; }
        public DateTime slaRealResponseDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime resolvedIn { get; set; }
        public DateTime reopenedIn { get; set; }
        public DateTime closedIn { get; set; }
        public DateTime lastActionDate { get; set; }
        public DateTime lastUpdate { get; set; }

        public bool slaSolutionChangedByUser { get; set; }
        public bool resolvedInFirstCall { get; set; }
        public bool slaSolutionDateIsPaused { get; set; }

        public Person? owner { get; set; }
        public Person? createdBy { get; set; }
        public Person? slaSolutionChangedBy { get; set; }

        public List<Client>? clients { get; set; }
        public List<Action>? actions { get; set; }
    }
}