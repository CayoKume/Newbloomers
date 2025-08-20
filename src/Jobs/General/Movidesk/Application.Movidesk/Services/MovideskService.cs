using Application.Core.Interfaces;
using Domain.Core.Enums;
using Domain.Movidesk.Models.Tickets;
using Domain.Movidesk.Interfaces.Apis;
using Domain.Movidesk.Interfaces.Repositorys;
using FluentValidation;
using Application.Movidesk.Interfaces.Services;

namespace Application.Movidesk.Services
{
    public class MovideskService : IMovideskService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IMovideskRepository _movideskRepository;

        private readonly IValidator<Domain.Movidesk.Dtos.Persons.Person> _personValidator;

        private static string GetPersonsJsonCache = String.Empty;

        public MovideskService(IAPICall apiCall, ILoggerService logger, IMovideskRepository movideskRepository) =>
            (_apiCall, _logger, _movideskRepository) = (apiCall, logger, movideskRepository);

        public Task<bool> GetPerson()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetPersons()
        {
            _logger
              .Clear()
              .AddLog(EnumJob.AfterSaleEcommerces);

            var _listSomenteNovos = new List<Domain.Movidesk.Models.Persons.Person>();

            var token = await _movideskRepository.GetTokenAsync();

            var response = await _apiCall.GetAsync(
                rote: "persons",
                token: token.Token
            );

            var hash = _logger.ComputeSha256Hash(response);

            if (!GetPersonsJsonCache.Equals(hash))
            {
                var persons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Domain.Movidesk.Dtos.Persons.Person>>(response);

                foreach (var person in persons)
                {
                    var validations = _personValidator.Validate(person);

                    if (validations.Errors.Count() > 0)
                    {
                        validations.Errors.ForEach(x =>
                            _logger.AddMessage(
                                message: $"Error when convert record - person_id: {person.id} | document: {person.cpfCnpj}\n" +
                                            $"{x}"
                            )
                        );

                        continue;
                    }

                    _listSomenteNovos.Add(new Domain.Movidesk.Models.Persons.Person(person: person));
                }

                GetPersonsJsonCache = hash;
            }

            _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public Task<bool> GetService()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetServices()
        {
            var token = await _movideskRepository.GetTokenAsync();

            var response = await _apiCall.GetAsync(
                rote: "services",
                token: token.Token
            );

            //var services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Service>>(response);

            return true;
        }

        public Task<bool> GetTicket()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetTickets()
        {
            var token = await _movideskRepository.GetTokenAsync();

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
                token: token.Token,
                filters: filters,
                selectItens: selectItens,
                expandItens: expandItens
            );

            var tickets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ticket>>(response);

            return true;
        }
    }
}
