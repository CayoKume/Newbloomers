using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxMovimentoTrocasService : ILinxMovimentoTrocasService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxMovimentoTrocas> _linxMicrovixRepositoryBase;
        private readonly ILinxMovimentoTrocasRepository _linxMovimentoTrocasRepository;
        private static ILinxMovimentoTrocasServiceCache _linxMovimentoTrocasServiceCache { get; set; } = new LinxMovimentoTrocasServiceCache();

        public LinxMovimentoTrocasService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxMovimentoTrocas> linxMicrovixRepositoryBase,
            ILinxMovimentoTrocasRepository linxMovimentoTrocasRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxMovimentoTrocasRepository = linxMovimentoTrocasRepository;
        }

        public List<LinxMovimentoTrocas?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxMovimentoTrocas>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxMovimentoTrocas(
                        listValidations: validations,
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        identificador: records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault(),
                        num_vale: records[i].Where(pair => pair.Key == "num_vale").Select(pair => pair.Value).FirstOrDefault(),
                        valor_vale: records[i].Where(pair => pair.Key == "valor_vale").Select(pair => pair.Value).FirstOrDefault(),
                        motivo: records[i].Where(pair => pair.Key == "motivo").Select(pair => pair.Value).FirstOrDefault(),
                        doc_origem: records[i].Where(pair => pair.Key == "doc_origem").Select(pair => pair.Value).FirstOrDefault(),
                        serie_origem: records[i].Where(pair => pair.Key == "serie_origem").Select(pair => pair.Value).FirstOrDefault(),
                        doc_venda: records[i].Where(pair => pair.Key == "doc_venda").Select(pair => pair.Value).FirstOrDefault(),
                        serie_venda: records[i].Where(pair => pair.Key == "serie_venda").Select(pair => pair.Value).FirstOrDefault(),
                        excluido: records[i].Where(pair => pair.Key == "excluido").Select(pair => pair.Value).FirstOrDefault(),
                        desfazimento: records[i].Where(pair => pair.Key == "desfazimento").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        vale_cod_cliente: records[i].Where(pair => pair.Key == "vale_cod_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        vale_codigoproduto: records[i].Where(pair => pair.Key == "vale_codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        id_vale_ordem_servico_externa: records[i].Where(pair => pair.Key == "id_vale_ordem_servico_externa").Select(pair => pair.Value).FirstOrDefault(),
                        doc_venda_origem: records[i].Where(pair => pair.Key == "doc_venda_origem").Select(pair => pair.Value).FirstOrDefault(),
                        serie_venda_origem: records[i].Where(pair => pair.Key == "serie_venda_origem").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | num_vale: {records[i].Where(pair => pair.Key == "num_vale").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | num_vale: {records[i].Where(pair => pair.Key == "num_vale").Select(pair => pair.Value).FirstOrDefault()}",
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
