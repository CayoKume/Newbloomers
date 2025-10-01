
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxServicos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_setor { get; private set; }
        public Int64? cod_servico { get; private set; }
        public string? nome { get; private set; }
        public string? desc_setor { get; private set; }
        public Int32? id_linha { get; private set; }
        public string? desc_linha { get; private set; }
        public Int32? id_marca { get; private set; }
        public string? desc_marca { get; private set; }
        public DateTime? dt_update { get; private set; }
        public string? operacao_servico { get; private set; }
        public string? servico_km { get; private set; }
        public string? desativado { get; private set; }
        public string? cod_lc11603 { get; private set; }
        public string? codigo_nbs { get; private set; }
        public DateTime? dt_inclusao { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_ws { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxServicos() { }

        public LinxServicos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxServicos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_setor = CustomConvertersExtensions.ConvertToInt32Validation(record.id_setor);
            this.id_linha = CustomConvertersExtensions.ConvertToInt32Validation(record.id_linha);
            this.id_marca = CustomConvertersExtensions.ConvertToInt32Validation(record.id_marca);
            this.cod_servico = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_servico);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.dt_update = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_update);
            this.dt_inclusao = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_inclusao);
            this.nome = record.nome;
            this.desc_setor = record.desc_setor;
            this.desc_linha = record.desc_linha;
            this.desc_marca = record.desc_marca;
            this.cod_lc11603 = record.cod_lc11603;
            this.operacao_servico = record.operacao_servico;
            this.desativado = record.desativado;
            this.codigo_ws = record.codigo_ws;
            this.codigo_nbs = record.codigo_nbs;
            this.servico_km = record.servico_km;
        }
    }
}
