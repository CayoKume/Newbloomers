using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxClientesFornecService : ILinxClientesFornecService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornec> _validator;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxClientesFornecRepository _linxClientesFornecRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly ILinxClientesFornecCommandHandler _linxClientesFornecCommandHandler;
        private static List<string?> _linxClientesFornecCache { get; set; } = new List<string?>();

        public LinxClientesFornecService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            ILinxClientesFornecRepository linxClientesFornecRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornec> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            ILinxClientesFornecCommandHandler linxClientesFornecCommandHandler
        )
        {
            _apiCall = apiCall;
            _validator = validator;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxClientesFornecRepository = linxClientesFornecRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _linxClientesFornecCommandHandler = linxClientesFornecCommandHandler;
        }

        public List<LinxClientesFornec?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxClientesFornec>();
            
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornec(
                        cod_cliente: records[i].Where(pair => pair.Key == "cod_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        razao_cliente: records[i].Where(pair => pair.Key == "razao_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        nome_cliente: records[i].Where(pair => pair.Key == "nome_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        doc_cliente: records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_cliente: records[i].Where(pair => pair.Key == "tipo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        endereco_cliente: records[i].Where(pair => pair.Key == "endereco_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        numero_rua_cliente: records[i].Where(pair => pair.Key == "numero_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        complement_end_cli: records[i].Where(pair => pair.Key == "complement_end_cli").Select(pair => pair.Value).FirstOrDefault(),
                        bairro_cliente: records[i].Where(pair => pair.Key == "bairro_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cep_cliente: records[i].Where(pair => pair.Key == "cep_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cidade_cliente: records[i].Where(pair => pair.Key == "cidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        uf_cliente: records[i].Where(pair => pair.Key == "uf_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        pais: records[i].Where(pair => pair.Key == "pais").Select(pair => pair.Value).FirstOrDefault(),
                        fone_cliente: records[i].Where(pair => pair.Key == "fone_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        email_cliente: records[i].Where(pair => pair.Key == "email_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        sexo: records[i].Where(pair => pair.Key == "sexo").Select(pair => pair.Value).FirstOrDefault(),
                        data_cadastro: records[i].Where(pair => pair.Key == "data_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        data_nascimento: records[i].Where(pair => pair.Key == "data_nascimento").Select(pair => pair.Value).FirstOrDefault(),
                        cel_cliente: records[i].Where(pair => pair.Key == "cel_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        inscricao_estadual: records[i].Where(pair => pair.Key == "inscricao_estadual").Select(pair => pair.Value).FirstOrDefault(),
                        incricao_municipal: records[i].Where(pair => pair.Key == "incricao_municipal").Select(pair => pair.Value).FirstOrDefault(),
                        identidade_cliente: records[i].Where(pair => pair.Key == "identidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cartao_fidelidade: records[i].Where(pair => pair.Key == "cartao_fidelidade").Select(pair => pair.Value).FirstOrDefault(),
                        cod_ibge_municipio: records[i].Where(pair => pair.Key == "cod_ibge_municipio").Select(pair => pair.Value).FirstOrDefault(),
                        classe_cliente: records[i].Where(pair => pair.Key == "classe_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        matricula_conveniado: records[i].Where(pair => pair.Key == "matricula_conveniado").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_cadastro: records[i].Where(pair => pair.Key == "tipo_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        empresa_cadastro: records[i].Where(pair => pair.Key == "empresa_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        id_estado_civil: records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault(),
                        fax_cliente: records[i].Where(pair => pair.Key == "fax_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        site_cliente: records[i].Where(pair => pair.Key == "site_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cliente_anonimo: records[i].Where(pair => pair.Key == "cliente_anonimo").Select(pair => pair.Value).FirstOrDefault(),
                        limite_compras: records[i].Where(pair => pair.Key == "limite_compras").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_ws: records[i].Where(pair => pair.Key == "codigo_ws").Select(pair => pair.Value).FirstOrDefault(),
                        limite_credito_compra: records[i].Where(pair => pair.Key == "limite_credito_compra").Select(pair => pair.Value).FirstOrDefault(),
                        id_classe_fiscal: records[i].Where(pair => pair.Key == "id_classe_fiscal").Select(pair => pair.Value).FirstOrDefault(),
                        obs: records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).FirstOrDefault(),
                        mae: records[i].Where(pair => pair.Key == "mae").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - doc_cliente: {records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault()} | razao_cliente: {records[i].Where(pair => pair.Key == "razao_cliente").Select(pair => pair.Value).FirstOrDefault()}" + "\n";
		
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
		
                        _logger.AddMessage(message);
                    }
		
                    list.Add(new LinxClientesFornec(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - doc_cliente: {records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault()} | razao_cliente: {records[i].Where(pair => pair.Key == "razao_cliente").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxClientesFornec);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[doc_cliente]", identificador).Replace("[data_inicial]", "2000-01-01").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxClientesFornecRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.LinxClientesFornec);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlTimestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMinTimestampQuery(jobParameter.schema, jobParameter.tableName, "dt_update");
            string? timestamp = await _coreRepository.GetRecord<string>(sqlTimestamp);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                        parametersList: parameters.Replace("[0]", timestamp).Replace("[data_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}").Replace("[dt_update_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[dt_update_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                        jobParameter: jobParameter,
                        cnpj_emp: jobParameter.docMainCompany
                    );

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_linxClientesFornecCache.Count == 0)
                {
                    var list = await _linxClientesFornecRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.doc_cliente)
                                    .ToList()
                    );

                    _linxClientesFornecCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxClientesFornecCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxClientesFornecRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxClientesFornecCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> IntegrityLockLinxClientesFornecRegisters(LinxAPIParam jobParameter)
        {
            var _listSomenteNovos = new List<LinxClientesFornec>();

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string integritySql = _linxClientesFornecCommandHandler.CreateIntegrityLockQuery();
            var clientes = await _coreRepository.GetRecords<string>(integritySql);

            foreach (var cliente in clientes)
            {
                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters.Replace("[0]", "0").Replace("[doc_cliente]", cliente).Replace("[data_inicial]", "2000-01-01").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                                jobParameter: jobParameter,
                                cnpj_emp: jobParameter.docMainCompany
                            );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                    _listSomenteNovos.AddRange(listRecords);
                } 
            }

            if (_listSomenteNovos.Count() > 0)
            {
                _linxClientesFornecRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
            }

            return true;
        }
    }
}


