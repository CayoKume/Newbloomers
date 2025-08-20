namespace Domain.Movidesk.Dtos.Tickets
{
    public class Ticket
    {
        public string? id { get; set; }
        public string? protocol { get; set; }
        public string? type { get; set; }
        public string? subject { get; set; }
        public string? category { get; set; }
        public string? urgency { get; set; }
        public string? status { get; set; }
        public string? baseStatus { get; set; }
        public string? justification { get; set; }
        public string? origin { get; set; }
        public string? createdDate { get; set; }
        public string? originEmailAccount { get; set; }
        public Createdby? owner { get; set; }
        public string? ownerTeam { get; set; }
        public Createdby? createdBy { get; set; }
        public string[]? serviceFull { get; set; }
        public string? serviceFirstLevelId { get; set; }
        public string? serviceFirstLevel { get; set; }
        public string? serviceSecondLevel { get; set; }
        public string? serviceThirdLevel { get; set; }
        public string? contactForm { get; set; }
        public string[]? tags { get; set; }
        public string? cc { get; set; }
        public string? resolvedIn { get; set; }
        public string? reopenedIn { get; set; }
        public string? closedIn { get; set; }
        public string? lastActionDate { get; set; }
        public string? actionCount { get; set; }
        public string? lastUpdate { get; set; }
        public string? lifeTimeWorkingTime { get; set; }
        public string? stoppedTime { get; set; }
        public string? stoppedTimeWorkingTime { get; set; }
        public string? resolvedInFirstCall { get; set; }
        public string? chatWidget { get; set; }
        public string? chatGroup { get; set; }
        public string? chatTalkTime { get; set; }
        public string? chatWaitingTime { get; set; }
        public string? sequence { get; set; }
        public string? slaAgreement { get; set; }
        public string? slaAgreementRule { get; set; }
        public string? slaSolutionTime { get; set; }
        public string? slaResponseTime { get; set; }
        public string? slaSolutionChangedByUser { get; set; }
        public Createdby? slaSolutionChangedBy { get; set; }
        public string? slaSolutionDate { get; set; }
        public string? slaSolutionDateIsPaused { get; set; }
        public string? slaResponseDate { get; set; }
        public string? slaRealResponseDate { get; set; }
        public Client[]? clients { get; set; }
        public Action[]? actions { get; set; }
    }
}