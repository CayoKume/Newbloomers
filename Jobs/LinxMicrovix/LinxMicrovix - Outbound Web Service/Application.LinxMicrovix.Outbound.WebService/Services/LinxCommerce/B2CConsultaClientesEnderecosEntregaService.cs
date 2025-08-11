using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaClientesEnderecosEntregaService : IB2CConsultaClientesEnderecosEntregaService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClientesEnderecosEntregaRepository _b2cConsultaClientesEnderecosEntregaRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string?> _b2cConsultaClientesEnderecosEntregaCache { get; set; } = new List<string?>();

        public B2CConsultaClientesEnderecosEntregaService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            IB2CConsultaClientesEnderecosEntregaRepository b2cConsultaClientesEnderecosEntregaRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _b2cConsultaClientesEnderecosEntregaRepository = b2cConsultaClientesEnderecosEntregaRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<B2CConsultaClientesEnderecosEntrega?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesEnderecosEntrega>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesEnderecosEntrega(
                        id_endereco_entrega: records[i].Where(pair => pair.Key == "id_endereco_entrega").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_erp: records[i].Where(pair => pair.Key == "cod_cliente_erp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_b2c: records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault(),
                        endereco_cliente: records[i].Where(pair => pair.Key == "endereco_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        numero_rua_cliente: records[i].Where(pair => pair.Key == "numero_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        complemento_end_cli: records[i].Where(pair => pair.Key == "complemento_end_cli").Select(pair => pair.Value).FirstOrDefault(),
                        cep_cliente: records[i].Where(pair => pair.Key == "cep_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        bairro_cliente: records[i].Where(pair => pair.Key == "bairro_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cidade_cliente: records[i].Where(pair => pair.Key == "cidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        uf_cliente: records[i].Where(pair => pair.Key == "uf_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        descricao: records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault(),
                        principal: records[i].Where(pair => pair.Key == "principal").Select(pair => pair.Value).FirstOrDefault(),
                        id_cidade: records[i].Where(pair => pair.Key == "id_cidade").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record: id_endereco_entrega: {records[i].Where(pair => pair.Key == "id_endereco_entrega").Select(pair => pair.Value).FirstOrDefault()} | cod_cliente_b2c: {records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record: id_endereco_entrega: {records[i].Where(pair => pair.Key == "id_endereco_entrega").Select(pair => pair.Value).FirstOrDefault()} | cod_cliente_b2c: {records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
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
               .AddLog(EnumJob.B2CConsultaClientesEnderecosEntrega);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[cod_cliente_b2c]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _b2cConsultaClientesEnderecosEntregaRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.B2CConsultaClientesEnderecosEntrega);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlTimestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMinTimestampQuery(jobParameter.schema, jobParameter.tableName, "LASTUPDATEON");
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

                if (_b2cConsultaClientesEnderecosEntregaCache.Count == 0)
                {
                    var list = await _b2cConsultaClientesEnderecosEntregaRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.id_endereco_entrega)
                                    .ToList()
                    );

                    _b2cConsultaClientesEnderecosEntregaCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesEnderecosEntregaCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _b2cConsultaClientesEnderecosEntregaRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _b2cConsultaClientesEnderecosEntregaCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
