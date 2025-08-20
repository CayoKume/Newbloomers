using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaProdutosService : IB2CConsultaProdutosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IB2CConsultaProdutosRepository _b2cConsultaProdutosRepository;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutos> _validator;
        private static List<string?> _b2cConsultaProdutosCache { get; set; } = new List<string?>();

        public B2CConsultaProdutosService(
            IAPICall apiCall,
            ILoggerService logger,
            ICoreRepository coreRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutos> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            IB2CConsultaProdutosRepository b2cConsultaProdutosRepository
        )
        {
            _validator = validator;
            _apiCall = apiCall;
            _logger = logger;
            _coreRepository = coreRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _b2cConsultaProdutosRepository = b2cConsultaProdutosRepository;
        }

        public List<B2CConsultaProdutos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaProdutos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutos(
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        referencia: records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).FirstOrDefault(),
                        codauxiliar1: records[i].Where(pair => pair.Key == "codauxiliar1").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_basica: records[i].Where(pair => pair.Key == "descricao_basica").Select(pair => pair.Value).FirstOrDefault(),
                        nome_produto: records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).FirstOrDefault(),
                        peso_liquido: records[i].Where(pair => pair.Key == "peso_liquido").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_setor: records[i].Where(pair => pair.Key == "codigo_setor").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_linha: records[i].Where(pair => pair.Key == "codigo_linha").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_marca: records[i].Where(pair => pair.Key == "codigo_marca").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_colecao: records[i].Where(pair => pair.Key == "codigo_colecao").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_espessura: records[i].Where(pair => pair.Key == "codigo_espessura").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_grade1: records[i].Where(pair => pair.Key == "codigo_grade1").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_grade2: records[i].Where(pair => pair.Key == "codigo_grade2").Select(pair => pair.Value).FirstOrDefault(),
                        unidade: records[i].Where(pair => pair.Key == "unidade").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_classificacao: records[i].Where(pair => pair.Key == "codigo_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                        dt_cadastro: records[i].Where(pair => pair.Key == "dt_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        observacao: records[i].Where(pair => pair.Key == "observacao").Select(pair => pair.Value).FirstOrDefault(),
                        cod_fornecedor: records[i].Where(pair => pair.Key == "cod_fornecedor").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        altura_para_frete: records[i].Where(pair => pair.Key == "altura_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        largura_para_frete: records[i].Where(pair => pair.Key == "largura_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        comprimento_para_frete: records[i].Where(pair => pair.Key == "comprimento_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        peso_bruto: records[i].Where(pair => pair.Key == "peso_bruto").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_completa_commerce: records[i].Where(pair => pair.Key == "descricao_completa_commerce").Select(pair => pair.Value).FirstOrDefault(),
                        canais_ecommerce_publicados: records[i].Where(pair => pair.Key == "canais_ecommerce_publicados").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_integracao_oms: records[i].Where(pair => pair.Key == "codigo_integracao_oms").Select(pair => pair.Value).FirstOrDefault(),
                        inicio_publicacao_produto: records[i].Where(pair => pair.Key == "inicio_publicacao_produto").Select(pair => pair.Value).FirstOrDefault(),
                        fim_publicacao_produto: records[i].Where(pair => pair.Key == "fim_publicacao_produto").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - codigoproduto: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} | nome_produto: {records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).FirstOrDefault()} ";
    
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
    
                        _logger.AddMessage(message);
                    }
    
                    list.Add(new B2CConsultaProdutos(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - codigoproduto: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} | nome_produto: {records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                            exceptionMessage: ex.StackTrace
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaProdutos);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[codigoproduto]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _b2cConsultaProdutosRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.B2CConsultaProdutos);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlCnpjsEmp = _linxMicrovixCommandHandler.CreateGetB2CCompanysQuery();
            var cnpjs_emp = await _coreRepository.GetRecords<Company?>(sql);

            foreach (var cnpj_emp in cnpjs_emp)
            {
                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", "0"),
                            jobParameter: jobParameter,
                            cnpj_emp: cnpj_emp.doc_company
                        );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_b2cConsultaProdutosCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaProdutosRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaProdutosCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaProdutosCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaProdutosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaProdutosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                    }

                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                }
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}




