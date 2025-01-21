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
    public class LinxMovimentoCartoesService : ILinxMovimentoCartoesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxMovimentoCartoes> _linxMicrovixRepositoryBase;
        private readonly ILinxMovimentoCartoesRepository _linxMovimentoCartoesRepository;
        private static ILinxMovimentoCartoesServiceCache _linxMovimentoCartoesServiceCache { get; set; } = new LinxMovimentoCartoesServiceCache();

        public LinxMovimentoCartoesService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxMovimentoCartoes> linxMicrovixRepositoryBase,
            ILinxMovimentoCartoesRepository linxMovimentoCartoesRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxMovimentoCartoesRepository = linxMovimentoCartoesRepository;
        }

        public List<LinxMovimentoCartoes?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxMovimentoCartoes>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxMovimentoCartoes(
                        listValidations: validations,
                        identificador: records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        codlojasitef: records[i].Where(pair => pair.Key == "codlojasitef").Select(pair => pair.Value).FirstOrDefault(),
                        data_lancamento: records[i].Where(pair => pair.Key == "data_lancamento").Select(pair => pair.Value).FirstOrDefault(),
                        cupomfiscal: records[i].Where(pair => pair.Key == "cupomfiscal").Select(pair => pair.Value).FirstOrDefault(),
                        credito_debito: records[i].Where(pair => pair.Key == "credito_debito").Select(pair => pair.Value).FirstOrDefault(),
                        id_cartao_bandeira: records[i].Where(pair => pair.Key == "id_cartao_bandeira").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_bandeira: records[i].Where(pair => pair.Key == "descricao_bandeira").Select(pair => pair.Value).FirstOrDefault(),
                        valor: records[i].Where(pair => pair.Key == "valor").Select(pair => pair.Value).FirstOrDefault(),
                        ordem_cartao: records[i].Where(pair => pair.Key == "ordem_cartao").Select(pair => pair.Value).FirstOrDefault(),
                        nsu_host: records[i].Where(pair => pair.Key == "nsu_host").Select(pair => pair.Value).FirstOrDefault(),
                        nsu_sitef: records[i].Where(pair => pair.Key == "nsu_sitef").Select(pair => pair.Value).FirstOrDefault(),
                        cod_autorizacao: records[i].Where(pair => pair.Key == "cod_autorizacao").Select(pair => pair.Value).FirstOrDefault(),
                        id_antecipacoes_financeiras: records[i].Where(pair => pair.Key == "id_antecipacoes_financeiras").Select(pair => pair.Value).FirstOrDefault(),
                        transacao_servico_terceiro: records[i].Where(pair => pair.Key == "transacao_servico_terceiro").Select(pair => pair.Value).FirstOrDefault(),
                        texto_comprovante: records[i].Where(pair => pair.Key == "texto_comprovante").Select(pair => pair.Value).FirstOrDefault(),
                        id_maquineta_pos: records[i].Where(pair => pair.Key == "id_maquineta_pos").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_maquineta: records[i].Where(pair => pair.Key == "descricao_maquineta").Select(pair => pair.Value).FirstOrDefault(),
                        serie_maquineta: records[i].Where(pair => pair.Key == "serie_maquineta").Select(pair => pair.Value).FirstOrDefault(),
                        cartao_prepago: records[i].Where(pair => pair.Key == "cartao_prepago").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | cupomfiscal: {records[i].Where(pair => pair.Key == "cupomfiscal").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | cupomfiscal: {records[i].Where(pair => pair.Key == "cupomfiscal").Select(pair => pair.Value).FirstOrDefault()}",
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
