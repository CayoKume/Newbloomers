namespace Domain.Movidesk.Entities
{
    public class SurveyResponse
    {
        public Int32? id { get; set; }
        public DateTime? responseDate { get; set; }
        public Int32? satisfactionSurveyModel { get; set; }
        public Int32? satisfactionSurveyNetPromoterScoreResponse { get; set; }
        public Int32? satisfactionSurveyPositiveNegativeResponse { get; set; }
        public Int32? satisfactionSurveySmileyFacesResponse { get; set; }
        public string? comments { get; set; }
        public PersonTicket? responsedBy { get; set; }
    }
}
