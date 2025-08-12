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
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxMovimentoPlanosService : ILinxMovimentoPlanosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoPlanos> _validator;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMovimentoPlanosRepository _linxMovimentoPlanosRepository;
        private static List<string?> _linxMovimentoPlanosCache { get; set; } = new List<string?>();

        public LinxMovimentoPlanosService(
            IAPICall apiCall,
            ILoggerService logger,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoPlanos> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            ILinxMovimentoPlanosRepository linxMovimentoPlanosRepository
        )
        {
            _apiCall = apiCall;
            _validator = validator;
            _logger = logger;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMovimentoPlanosRepository = linxMovimentoPlanosRepository;
        }

        public List<LinxMovimentoPlanos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxMovimentoPlanos>();
            
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoPlanos(
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        identificador: records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault(),
                        plano: records[i].Where(pair => pair.Key == "plano").Select(pair => pair.Value).FirstOrDefault(),
                        desc_plano: records[i].Where(pair => pair.Key == "desc_plano").Select(pair => pair.Value).FirstOrDefault(),
                        total: records[i].Where(pair => pair.Key == "total").Select(pair => pair.Value).FirstOrDefault(),
                        qtde_parcelas: records[i].Where(pair => pair.Key == "qtde_parcelas").Select(pair => pair.Value).FirstOrDefault(),
                        indice_plano: records[i].Where(pair => pair.Key == "indice_plano").Select(pair => pair.Value).FirstOrDefault(),
                        cod_forma_pgto: records[i].Where(pair => pair.Key == "cod_forma_pgto").Select(pair => pair.Value).FirstOrDefault(),
                        forma_pgto: records[i].Where(pair => pair.Key == "forma_pgto").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_transacao: records[i].Where(pair => pair.Key == "tipo_transacao").Select(pair => pair.Value).FirstOrDefault(),
                        taxa_financeira: records[i].Where(pair => pair.Key == "taxa_financeira").Select(pair => pair.Value).FirstOrDefault(),
                        ordem_cartao: records[i].Where(pair => pair.Key == "ordem_cartao").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | desc_plano: {records[i].Where(pair => pair.Key == "desc_plano").Select(pair => pair.Value).FirstOrDefault()}" + "\n";
		
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
		
                        _logger.AddMessage(message);
                    }
		
                    list.Add(new LinxMovimentoPlanos(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | desc_plano: {records[i].Where(pair => pair.Key == "desc_plano").Select(pair => pair.Value).FirstOrDefault()}",
                            exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxMovimentoPlanos);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[identificador]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxMovimentoPlanosRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.LinxMovimentoPlanos);

            var xmls = new List<Dictionary<string?, string?>>();

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlCnpjsEmp = _linxMicrovixCommandHandler.CreateGetB2CCompanysQuery();
            var cnpjs_emp = await _coreRepository.GetRecords<Company?>(sql);

            foreach (var cnpj_emp in cnpjs_emp)
            {
                string? timestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMinTimestampWithCompanyQuery(
                    jobParameter.schema,
                    jobParameter.tableName,
                    columnDate: "lastupdateon",
                    columnCompany: "cnpj_emp",
                    companyValue: cnpj_emp.doc_company
                );

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", timestamp).Replace("[data_inicial]", $"{DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp.doc_company
                );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var result = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);
                xmls.AddRange(result);
            }

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_linxMovimentoPlanosCache.Count == 0)
                {
                    var list = await _linxMovimentoPlanosRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                    );

                    _linxMovimentoPlanosCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxMovimentoPlanosCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxMovimentoPlanosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxMovimentoPlanosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}


