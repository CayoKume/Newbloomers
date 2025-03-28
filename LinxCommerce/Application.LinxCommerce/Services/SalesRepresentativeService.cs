using Application.IntegrationsCore.Interfaces;
using Application.LinxCommerce.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Entities.SalesRepresentative;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys;
using FluentValidation;

namespace Application.LinxCommerce.Services
{
    public class SalesRepresentativeService : ISalesRepresentativeService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ISalesRepresentativeRepository _salesRepresentativeRepository;
        private readonly IValidator<SalesRepresentative> _validator;

        public SalesRepresentativeService(IAPICall apiCall, ILoggerService logger, ISalesRepresentativeRepository salesRepresentativeRepository, IValidator<SalesRepresentative> validator) =>
            (_apiCall, _logger, _salesRepresentativeRepository, _validator) = (apiCall, logger, salesRepresentativeRepository, validator);

        public Task<bool?> DeleteSalesRepresentative(int salesRepresentativeId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> GetSalesRepresentative(LinxCommerceJobParameter jobParameter, int? salesRepresentativeId)
        {
            try
            {
                var salesRepresentativeList = new List<SalesRepresentative>();

                var getSaleRepresentativeResponse = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: new { salesRepresentativeId },
                    route: "/v1/Sales/API.svc/web/GetSalesRepresentative"
                );

                var saleRepresentative = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSalesRepresentative.Root>(getSaleRepresentativeResponse);
                salesRepresentativeList.Add(saleRepresentative.SalesRepresentative);

                //_salesRepresentativeRepository.BulkInsertIntoTableRaw(jobParameter: jobParameter, registros: salesRepresentativeList);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool?> SaveSalesRepresentative()
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> SearchSalesRepresentative(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceSalesRepresentative);

                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 0 },
                    Where = $"",
                    WhereMetadata = "",
                    OrderBy = "SalesRepresentativeID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: objectRequest,
                    route: "/v1/Sales/API.svc/web/SearchSalesRepresentative"
                );

                var salesRepresentativeAPIList = new List<SalesRepresentative>();
                var salesRepresentativeIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchSalesRepresentative.Root>(response);
                
                foreach (var salesRepresentativeID in salesRepresentativeIDs.Result)
                {
                    var getSaleRepresentativeObjectRequest = new
                    {
                        salesRepresentativeID.SalesRepresentativeID
                    };

                    var getSaleRepresentativeResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        objRequest: getSaleRepresentativeObjectRequest,
                        route: "/v1/Sales/API.svc/web/GetSalesRepresentative"
                    );

                    var saleRepresentative = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSalesRepresentative.Root>(getSaleRepresentativeResponse);
                    var validations = _validator.Validate(saleRepresentative.SalesRepresentative);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - SalesRepresentativeID: {saleRepresentative.SalesRepresentative.SalesRepresentativeID} | Name: {saleRepresentative.SalesRepresentative.Name}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    salesRepresentativeAPIList.Add(new SalesRepresentative(saleRepresentative.SalesRepresentative, getSaleRepresentativeResponse));
                }

                if (salesRepresentativeAPIList.Count() > 0)
                {
                    _salesRepresentativeRepository.BulkInsertIntoTableRaw(jobParameter: jobParameter, registros: salesRepresentativeAPIList, _logger.GetExecutionGuid());

                    salesRepresentativeAPIList.ForEach(s =>
                        _logger.AddRecord(
                            s.SalesRepresentativeID.ToString(), 
                            s.Responses
                                .Where(pair => pair.Key == s.SalesRepresentativeID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );
                    
                    _logger.AddMessage(
                            $"Concluída com sucesso: {salesRepresentativeAPIList.Count()} registro(s) novo(s) inserido(s)!"
                        );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {salesRepresentativeAPIList.Count()} registro(s) novo(s) inserido(s)!"
                    );
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
    }
}
