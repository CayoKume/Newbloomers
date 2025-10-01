
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoGiftCard
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? empresa { get; private set; }
        public DateTime? data_transacao { get; private set; }
        public Int32? operacao { get; private set; }
        public string? nsu_cliente { get; private set; }
        public string? nsu_host { get; private set; }
        public decimal? valor { get; private set; }
        public string? json_envio { get; private set; }
        public string json_retorno { get; private set; }
        public Int32? qtde_tentativa { get; private set; }
        public string? aprovado_barramento { get; private set; }
        public bool? estornada { get; private set; }
        public string? codigo_loja { get; private set; }
        public Guid? identificador_movimento { get; private set; }
        public string? numero_cartao { get; private set; }
        public Int32? plano { get; private set; }
        public bool? ambiente_producao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoGiftCard() { }

        public LinxMovimentoGiftCard(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoGiftCard record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.operacao = CustomConvertersExtensions.ConvertToInt32Validation(record.operacao);
            this.qtde_tentativa = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_tentativa);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.estornada = CustomConvertersExtensions.ConvertToBooleanValidation(record.estornada);
            this.ambiente_producao = CustomConvertersExtensions.ConvertToBooleanValidation(record.ambiente_producao);
            this.data_transacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_transacao);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.identificador_movimento = Guid.Parse(record.identificador_movimento);
            this.nsu_cliente = record.nsu_cliente;
            this.nsu_host = record.nsu_host;
            this.json_envio = record.json_envio;
            this.json_retorno = record.json_retorno;
            this.aprovado_barramento = record.aprovado_barramento;
            this.codigo_loja = record.codigo_loja;
            this.numero_cartao = record.numero_cartao;
        }
    }
}
