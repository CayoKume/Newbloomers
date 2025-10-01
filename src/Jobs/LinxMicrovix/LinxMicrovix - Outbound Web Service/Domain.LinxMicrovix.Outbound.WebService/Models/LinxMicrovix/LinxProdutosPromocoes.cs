
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosPromocoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int64? cod_produto { get; private set; }
        public decimal? preco_promocao { get; private set; }
        public DateTime? data_inicio_promocao { get; private set; }
        public DateTime? data_termino_promocao { get; private set; }
        public DateTime? data_cadastro_promocao { get; private set; }
        public string? promocao_ativa { get; private set; }
        public Int64? id_campanha { get; private set; }
        public string? nome_campanha { get; private set; }
        public bool? promocao_opcional { get; private set; }
        public decimal? custo_total_campanha { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosPromocoes() { }

        public LinxProdutosPromocoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosPromocoes record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.id_campanha = CustomConvertersExtensions.ConvertToInt64Validation(record.id_campanha);
            this.data_inicio_promocao = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_inicio_promocao);
            this.data_termino_promocao = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_termino_promocao);
            this.data_cadastro_promocao = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_cadastro_promocao);
            this.preco_promocao = CustomConvertersExtensions.ConvertToDecimalValidation(record.preco_promocao);
            this.custo_total_campanha = CustomConvertersExtensions.ConvertToDecimalValidation(record.custo_total_campanha);
            this.promocao_opcional = CustomConvertersExtensions.ConvertToBooleanValidation(record.promocao_opcional);
            this.promocao_ativa = record.promocao_ativa;
            this.cnpj_emp = record.cnpj_emp;
            this.nome_campanha = record.nome_campanha;
            this.recordKey = $"[{record.portal}]|[{record.cnpj_emp}]|[{record.cod_produto}]|[{record.preco_promocao}]|[{record.data_inicio_promocao}]|[{record.data_termino_promocao}]|[{record.data_cadastro_promocao}]|[{record.promocao_ativa}]|[{record.id_campanha}]|[{record.nome_campanha}]|[{record.promocao_opcional}]|[{record.custo_total_campanha}]";
            this.recordXml = recordXml;
        }
    }
}
