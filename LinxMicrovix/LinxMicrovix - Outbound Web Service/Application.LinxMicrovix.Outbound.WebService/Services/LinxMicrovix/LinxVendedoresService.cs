using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix.Outbound.Web.Service.Application.Services.LinxMicrovix
{
    public class LinxVendedoresService : ILinxVendedoresService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxVendedores> _linxMicrovixRepositoryBase;
        private readonly ILinxVendedoresRepository _linxVendedoresRepository;
        private static List<string?> _linxVendedoresCache { get; set; } = new List<string?>();

        public LinxVendedoresService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxVendedores> linxMicrovixRepositoryBase,
            ILinxVendedoresRepository linxVendedoresRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxVendedoresRepository = linxVendedoresRepository;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxVendedores);

            var xmls = new List<Dictionary<string?, string?>>();
            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixCompanys();

            foreach (var cnpj_emp in cnpjs_emp)
            {
                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", "0").Replace("[data_upd_inicial]", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")).Replace("[data_upd_fim]", DateTime.Now.ToString("yyyy-MM-dd")),
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

                if (_linxVendedoresCache.Count == 0)
                {
                    var list = await _linxVendedoresRepository.GetRegistersExists();
                    _linxVendedoresCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxVendedoresCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxVendedoresRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(
                            key: _listSomenteNovos[i].recordKey,
                            xml: _listSomenteNovos[i].recordXml
                        );
                    }

                    _linxVendedoresCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

                    _logger.AddMessage(
                        $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                    );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                    );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxVendedores);

            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[cod_vendedor]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxVendedoresRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public List<LinxVendedores?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxVendedores>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxVendedores(
                        listValidations: validations,
                        cod_vendedor: records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        nome_vendedor: records[i].Where(pair => pair.Key == "nome_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_vendedor: records[i].Where(pair => pair.Key == "tipo_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_rua: records[i].Where(pair => pair.Key == "end_vend_rua").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_numero: records[i].Where(pair => pair.Key == "end_vend_numero").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_complemento: records[i].Where(pair => pair.Key == "end_vend_complemento").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_bairro: records[i].Where(pair => pair.Key == "end_vend_bairro").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_cep: records[i].Where(pair => pair.Key == "end_vend_cep").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_cidade: records[i].Where(pair => pair.Key == "end_vend_cidade").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_uf: records[i].Where(pair => pair.Key == "end_vend_uf").Select(pair => pair.Value).FirstOrDefault(),
                        fone_vendedor: records[i].Where(pair => pair.Key == "fone_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        mail_vendedor: records[i].Where(pair => pair.Key == "mail_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        dt_upd: records[i].Where(pair => pair.Key == "dt_upd").Select(pair => pair.Value).FirstOrDefault(),
                        cpf_vendedor: records[i].Where(pair => pair.Key == "cpf_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        data_admissao: records[i].Where(pair => pair.Key == "data_admissao").Select(pair => pair.Value).FirstOrDefault(),
                        data_saida: records[i].Where(pair => pair.Key == "data_saida").Select(pair => pair.Value).FirstOrDefault(),
                        matricula: records[i].Where(pair => pair.Key == "matricula").Select(pair => pair.Value).FirstOrDefault(),
                        id_tipo_venda: records[i].Where(pair => pair.Key == "id_tipo_venda").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_tipo_venda: records[i].Where(pair => pair.Key == "descricao_tipo_venda").Select(pair => pair.Value).FirstOrDefault(),
                        cargo: records[i].Where(pair => pair.Key == "cargo").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cod_vendedor: {records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault()} | nome_vendedor: {records[i].Where(pair => pair.Key == "nome_vendedor").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cod_vendedor: {records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault()} | nome_vendedor: {records[i].Where(pair => pair.Key == "nome_vendedor").Select(pair => pair.Value).FirstOrDefault()}",
                            exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }
    }
}
