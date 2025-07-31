namespace Domain.Movidesk.Dtos.Tickets
{
    public class Satisfactionsurveyrespons
    {
        public string? id { get; set; }
        public Createdby? responsedBy { get; set; }
        public string? responseDate { get; set; }
        public string? satisfactionSurveyModel { get; set; }
        public string? satisfactionSurveyNetPromoterScoreResponse { get; set; }
        public string? satisfactionSurveyPositiveNegativeResponse { get; set; }
        public string? satisfactionSurveySmileyFacesResponse { get; set; }
        public string? comments { get; set; }
    }
}
