using Application.IntegrationsCore.Interfaces;
using Application.LinxCommerce.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxCommerce.Entities.Customer;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys;

namespace Application.LinxCommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ICustomerRepository _customerRepository;
        private static List<Person> _personDboList = new List<Person>();

        public CustomerService(IAPICall apiCall, ILoggerService logger, ICustomerRepository customerRepository) =>
            (_apiCall, _logger, _customerRepository) = (apiCall, logger, customerRepository);

        public Task<bool?> AddCustomerRelation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> ApproveCustomerFile(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCustomer(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCustomerFile(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCustomerGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteCustomerRelation(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCompany(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCustomer(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCustomerFile(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCustomerGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCustomerStatus(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetCustomerStatusByIntegrationID(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetPerson(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetQueueCustomerFile(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetQueueCustomers(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> GetStatusModerationCustomerMarketplace(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RejectCustomerFile(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RunCustomerTransition(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCompany(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCustomer(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCustomerAddress(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCustomerFile(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCustomerGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SaveCustomerStatus(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SavePerson(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> SearchCustomer(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceCustomers);

                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 0 },
                    Where = $"(CreatedDate>=\"{DateTime.Now.AddDays(-1).Date:yyyy-MM-dd}T00:00:00\" && CreatedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    WhereMetadata = "",
                    OrderBy = "CustomerID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: objectRequest,
                    route: "/v1/Profile/API.svc/web/SearchCustomer"
                );

                var customersAPIList = new List<Person>();
                var customersIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchCustomer.Root>(response);

                if (_personDboList.Count() == 0)
                    _personDboList = await _customerRepository.GetRegistersExists(customersIDs.Result.Select(s => s.CustomerID));

                foreach (var customerID in customersIDs.Result)
                {
                    string route = String.Empty;

                    if (customerID.CustomerType == "P")
                        route = "GetPerson";
                    else
                        route = "GetCompany";

                    var getCustomerResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        intIdentifier: customerID.CustomerID,
                        route: "/v1/Profile/API.svc/web/" + route
                    );

                    var customer = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(getCustomerResponse);
                    customer.Responses.Add(customer.CustomerID, getCustomerResponse);

                    customersAPIList.Add(customer);
                }

                Person.Compare(customersAPIList, _personDboList);

                if (customersAPIList.Count() > 0)
                {
                    customersAPIList.ForEach(p =>
                        _logger.AddRecord(
                            p.CustomerID.ToString(),
                            p.Responses
                                .Where(pair => pair.Key == p.CustomerID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    _customerRepository.BulkInsertIntoTableRaw(jobParameter, customersAPIList);

                    _logger.AddMessage(
                        $"Concluída com sucesso: {customersAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {customersAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public Task<bool?> SearchCustomerGroup(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> UpdateModerationCustomerToSellerMarketplace(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> UpdateModerationSellerToCustomerMarketplace(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }
    }
}