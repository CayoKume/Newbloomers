using Application.Movidesk.Interfaces;
using Domain.Movidesk.Entities;
using Domain.Movidesk.Interfaces.Apis;
using Domain.Movidesk.Interfaces.Repositorys;

namespace Application.Movidesk.Services
{
    public class MovideskService : IMovideskService
    {
        private readonly IAPICall _apiCall;
        private readonly IMovideskRepository _movideskRepository;

        public MovideskService(IAPICall apiCall, IMovideskRepository movideskRepository) =>
            (_apiCall, _movideskRepository) = (apiCall, movideskRepository);

        public Task<bool> GetPerson()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetPersons()
        {
            try
            {
                //var token = await _movideskRepository.GetTokenAsync();
                var token = "7b034c69-b176-46f7-bc71-d6a290f18b73";

                var response = await _apiCall.GetAsync(
                    rote: "persons",
                    token: token
                );

                var persons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(response);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> GetService()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetServices()
        {
            try
            {
                //var token = await _movideskRepository.GetTokenAsync();
                var token = "7b034c69-b176-46f7-bc71-d6a290f18b73";

                var response = await _apiCall.GetAsync(
                    rote: "services",
                    token: token
                );

                var services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Service>>(response);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GetTicket()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetTickets()
        {
            try
            {
                //var token = await _movideskRepository.GetTokenAsync();
                var token = "7b034c69-b176-46f7-bc71-d6a290f18b73";
                var filters = "createdDate ge 2016-10-10T00:00:00.00z and createdDate le 2016-10-17T00:00:00.00z";

                var selectItens = "id, protocol, type, subject, category, urgency, status, baseStatus, justification," +
                                  "origin, createdDate, originEmailAccount, ownerTeam, serviceFirstLevelId, serviceFirstLevel," +
                                  "serviceSecondLevel, serviceThirdLevel, contactForm, serviceFull, tags, cc, resolvedIn," +
                                  "reopenedIn, closedIn, lastActionDate, actionCount, lastUpdate, lifeTimeWorkingTime," +
                                  "stoppedTime, stoppedTimeWorkingTime, resolvedInFirstCall, chatWidget, chatGroup, chatTalkTime," +
                                  "chatWaitingTime, sequence, slaAgreement, slaAgreementRule, slaSolutionTime, slaResponseTime," +
                                  "slaSolutionChangedByUser, slaSolutionDate, slaSolutionDateIsPaused, slaResponseDate, slaRealResponseDate";
                
                var expandItens = "owner($select=id, personType, profileType, businessName, email, phone)," +
                                  "createdBy($select=id, personType, profileType, businessName, email, phone)," +
                                  "slaSolutionChangedBy($select=id, personType, profileType, businessName, email, phone)," +
                                  "clients($select=id, personType, profileType, businessName, email, phone, isDeleted, organization)," +
                                  "actions($expand=createdBy, timeAppointments, expenses, attachments)," +
                                  "customFieldValues($expand=items)";

                var response = await _apiCall.GetAsync(
                    rote: "tickets",
                    token: token,
                    filters: filters,
                    selectItens: selectItens,
                    expandItens: expandItens
                );

                var tickets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ticket>>(response);

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
