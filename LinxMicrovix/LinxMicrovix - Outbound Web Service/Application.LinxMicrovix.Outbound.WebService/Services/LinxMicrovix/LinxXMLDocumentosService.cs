using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxXMLDocumentosService : ILinxXMLDocumentosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxXMLDocumentos> _linxMicrovixRepositoryBase;
        private readonly ILinxXMLDocumentosRepository _linxXMLDocumentosRepository;
        private static ILinxXMLDocumentosServiceCache _linxXMLDocumentosServiceCache { get; set; } = new LinxXMLDocumentosServiceCache();

        public LinxXMLDocumentosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxXMLDocumentos> linxMicrovixRepositoryBase,
            ILinxXMLDocumentosRepository linxXMLDocumentosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxXMLDocumentosRepository = linxXMLDocumentosRepository;
        }

        public List<LinxXMLDocumentos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxXMLDocumentos>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxXMLDocumentos(
                        listValidations: validations,
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        documento: records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault(),
                        serie: records[i].Where(pair => pair.Key == "serie").Select(pair => pair.Value).FirstOrDefault(),
                        data_emissao: records[i].Where(pair => pair.Key == "data_emissao").Select(pair => pair.Value).FirstOrDefault(),
                        chave_nfe: records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        situacao: records[i].Where(pair => pair.Key == "situacao").Select(pair => pair.Value).FirstOrDefault(),
                        xml: records[i].Where(pair => pair.Key == "xml").Select(pair => pair.Value).FirstOrDefault(),
                        excluido: records[i].Where(pair => pair.Key == "excluido").Select(pair => pair.Value).FirstOrDefault(),
                        identificador_microvix: records[i].Where(pair => pair.Key == "identificador_microvix").Select(pair => pair.Value).FirstOrDefault(),
                        dt_insert: records[i].Where(pair => pair.Key == "dt_insert").Select(pair => pair.Value).FirstOrDefault(),
                        nProtCanc: records[i].Where(pair => pair.Key == "nProtCanc").Select(pair => pair.Value).FirstOrDefault(),
                        nProtDeneg: records[i].Where(pair => pair.Key == "nProtDeneg").Select(pair => pair.Value).FirstOrDefault(),
                        nProtInut: records[i].Where(pair => pair.Key == "nProtInut").Select(pair => pair.Value).FirstOrDefault(),
                        xmlDistribuicao: records[i].Where(pair => pair.Key == "xmlDistribuicao").Select(pair => pair.Value).FirstOrDefault(),
                        cStat: records[i].Where(pair => pair.Key == "cStat").Select(pair => pair.Value).FirstOrDefault(),
                        id_nfe: records[i].Where(pair => pair.Key == "id_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente: records[i].Where(pair => pair.Key == "cod_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - documento: {records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault()} | chave_nfe: {records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - documento: {records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault()} | chave_nfe: {records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            throw new NotImplementedException();
        }
    }
}
