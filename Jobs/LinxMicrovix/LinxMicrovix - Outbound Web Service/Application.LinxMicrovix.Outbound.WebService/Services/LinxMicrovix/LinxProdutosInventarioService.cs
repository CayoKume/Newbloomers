using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Domain.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Handlers.Commands;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxProdutosInventarioService : ILinxProdutosInventarioService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxProdutosInventarioRepository _linxProdutosInventarioRepository;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;

        //NÃO ADICIONADO SISTEMA DE CACHE POR CONTA DE REGRA DE NEGOCIO, A PROC DE SINCRONIZAÇÃO PRECISA RECEBER TODOS OS DADOS DA API EM TODAS AS EXECUÇÕES DO JOB

        public LinxProdutosInventarioService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxProdutosInventarioRepository linxProdutosInventarioRepository,
            ICoreRepository coreRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxProdutosInventarioRepository = linxProdutosInventarioRepository;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;

        }

        public List<LinxProdutosInventario?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxProdutosInventario>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxProdutosInventario(
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        cod_barra: records[i].Where(pair => pair.Key == "cod_barra").Select(pair => pair.Value).FirstOrDefault(),
                        cod_deposito: records[i].Where(pair => pair.Key == "cod_deposito").Select(pair => pair.Value).FirstOrDefault(),
                        quantidade: records[i].Where(pair => pair.Key == "quantidade").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var contexto = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, contexto, validations, true);

                    if (validations.Count() > 0)
                    {
                        for (int j = 0; j < validations.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | cod_deposito: {records[i].Where(pair => pair.Key == "cod_deposito").Select(pair => pair.Value).FirstOrDefault()}\n" +
                                         $"{validations[j].ErrorMessage}"
                            );
                        }
                        continue;
                    }

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} cod_deposito: {records[i].Where(pair => pair.Key == "cod_deposito").Select(pair => pair.Value).FirstOrDefault()}| ",
                            exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? identificador2, string? identificador3, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxProdutosInventario);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters
                .Replace("[0]", "0")
                .Replace("[data_inventario]", "2000-01-01")
                .Replace("[data_inventario]", identificador2)
                .Replace("[cod_produto]", identificador)
                .Replace("[cod_deposito]", identificador3),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxProdutosInventarioRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                _logger.AddMessage(
                    $"Concluída com sucesso: {listRecords.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxProdutosInventario);

            var xmls = new List<Dictionary<string?, string?>>();
            
            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var sqlCnpjs = _linxMicrovixCommandHandler.CreateGetMicrovixCompanysQuery();
            var cnpjs_emp = await _coreRepository.GetRecords<Company>(sqlCnpjs);

            var depositos = await _linxProdutosInventarioRepository.GetProductsDepositsIds(jobParameter);

            foreach (var cod_deposito in depositos)
            {
                foreach (var cnpj_emp in cnpjs_emp)
                {

                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                        parametersList: parameters.Replace("[cod_deposito]", cod_deposito).Replace("[data_inventario]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                        jobParameter: jobParameter,
                        cnpj_emp: cnpj_emp.doc_company
                    );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var result = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);
                    xmls.AddRange(result);
                }
            }

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (listRecords.Count() > 0)
                {
                    _linxProdutosInventarioRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < listRecords.Count; i++)
                    {
                        _logger.AddRecord(
                            key: listRecords[i].recordKey,
                            xml: listRecords[i].recordXml
                        );
                    }
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {listRecords.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}
