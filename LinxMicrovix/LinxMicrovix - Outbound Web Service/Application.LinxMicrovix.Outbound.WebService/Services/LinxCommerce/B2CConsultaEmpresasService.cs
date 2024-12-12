using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaEmpresasService : IB2CConsultaEmpresasService
    {
        private readonly IAPICall _apiCall;
        ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaEmpresas> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaEmpresasRepository _b2cConsultaEmpresasRepository;
        private static IB2CConsultaEmpresasServiceCache _b2cConsultaEmpresasCache { get; set; } = new B2CConsultaEmpresasServiceCache();

        public B2CConsultaEmpresasService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaEmpresas> linxMicrovixRepositoryBase,
            IB2CConsultaEmpresasRepository b2cConsultaEmpresasRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaEmpresasRepository = b2cConsultaEmpresasRepository;
        }

        public List<B2CConsultaEmpresas?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaEmpresas>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaEmpresas(
                        listValidations: validations,
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        nome_emp: records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpjEmp").Select(pair => pair.Value).FirstOrDefault(),
                        end_unidade: records[i].Where(pair => pair.Key == "end_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        complemento_end_unidade: records[i].Where(pair => pair.Key == "complemento_end_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        nr_rua_unidade: records[i].Where(pair => pair.Key == "nr_rua_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        bairro_unidade: records[i].Where(pair => pair.Key == "bairro_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        cep_unidade: records[i].Where(pair => pair.Key == "cep_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        cidade_unidade: records[i].Where(pair => pair.Key == "cidade_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        uf_unidade: records[i].Where(pair => pair.Key == "uf_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        email_unidade: records[i].Where(pair => pair.Key == "email_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        data_criacao: records[i].Where(pair => pair.Key == "data_criacao").Select(pair => pair.Value).FirstOrDefault(),
                        centro_distribuicao: records[i].Where(pair => pair.Key == "centro_distribuicao").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var contexto = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, contexto, validations, true);

                    if (validations.Count() > 0)
                    {
                        for (int j = 0; j < validations.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()} | nome_emp: {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault()}\n" +
                                         $"{validations[j].ErrorMessage}"
                            );
                        }
                        continue;
                    }

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new InternalException(
                        stage: EnumStages.DeserializeXMLToObject,
                        error: EnumError.Exception,
                        level: EnumMessageLevel.Error,
                        message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()} | nome_emp: {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<B2CConsultaEmpresas> _listSomenteNovos = new List<B2CConsultaEmpresas>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaEmpresas);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0"),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany
                );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_b2cConsultaEmpresasCache.GetList().Count == 0)
                    {
                        var list_existentes = await _b2cConsultaEmpresasRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaEmpresasCache.AddList(list_existentes);
                    }

                    _listSomenteNovos = _b2cConsultaEmpresasCache.FiltrarList(listRecords);
                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaEmpresasRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            var key = _b2cConsultaEmpresasCache.GetKey(_listSomenteNovos[i]);
                            if (_b2cConsultaEmpresasCache.GetDictionaryXml().ContainsKey(key))
                            {
                                var xml = _b2cConsultaEmpresasCache.GetDictionaryXml()[key];
                                _logger.AddRecord(key, xml);
                            }
                        }

                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);

                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                    }
                    else
                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);
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
                //await _logger.CommitAllChanges();
                _b2cConsultaEmpresasCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
