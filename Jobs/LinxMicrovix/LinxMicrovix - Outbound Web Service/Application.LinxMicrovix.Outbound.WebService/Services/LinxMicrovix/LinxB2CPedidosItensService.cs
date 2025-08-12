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
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxB2CPedidosItensService : ILinxB2CPedidosItensService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxB2CPedidosItens> _validator;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxB2CPedidosItensRepository _linxB2CPedidosItensRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string?> _linxB2CPedidosItensCache { get; set; } = new List<string?>();

        public LinxB2CPedidosItensService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            ILinxB2CPedidosItensRepository linxB2CPedidosItensRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxB2CPedidosItens> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _validator = validator;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxB2CPedidosItensRepository = linxB2CPedidosItensRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<LinxB2CPedidosItens?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxB2CPedidosItens>();
            
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxB2CPedidosItens(
                        id_pedido_item: records[i].Where(pair => pair.Key == "id_pedido_item").Select(pair => pair.Value).FirstOrDefault(),
                        id_pedido: records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        quantidade: records[i].Where(pair => pair.Key == "quantidade").Select(pair => pair.Value).FirstOrDefault(),
                        vl_unitario: records[i].Where(pair => pair.Key == "vl_unitario").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - id_pedido_item: {records[i].Where(pair => pair.Key == "id_pedido_item").Select(pair => pair.Value).FirstOrDefault()} | id_pedido: {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()}" + "\n";
		
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
		
                        _logger.AddMessage(message);
                    }
		
                    list.Add(new LinxB2CPedidosItens(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - id_pedido_item: {records[i].Where(pair => pair.Key == "id_pedido_item").Select(pair => pair.Value).FirstOrDefault()} | id_pedido: {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxB2CPedidosItens);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlTimestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMaxTimestampQuery(jobParameter.schema, jobParameter.tableName);
            string? timestamp = await _coreRepository.GetRecord<string>(sqlTimestamp);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                        parametersList: parameters.Replace("[0]", timestamp),
                        jobParameter: jobParameter,
                        cnpj_emp: jobParameter.docMainCompany
                    );

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_linxB2CPedidosItensCache.Count == 0)
                {
                    var list = await _linxB2CPedidosItensRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.id_pedido_item)
                                    .ToList()
                    );

                    _linxB2CPedidosItensCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxB2CPedidosItensCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxB2CPedidosItensRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxB2CPedidosItensCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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


