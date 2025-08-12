
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosDetalhes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int64? cod_produto { get; private set; }
        public string? cod_barra { get; private set; }
        public decimal? quantidade { get; private set; }
        public decimal? preco_custo { get; private set; }
        public decimal? preco_venda { get; private set; }
        public decimal? custo_medio { get; private set; }
        public Int32? id_config_tributaria { get; private set; }
        public string? desc_config_tributaria { get; private set; }
        public decimal? despesas1 { get; private set; }
        public decimal? qtde_minima { get; private set; }
        public decimal? qtde_maxima { get; private set; }
        public decimal? ipi { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? empresa { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosDetalhes() { }

        public LinxProdutosDetalhes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosDetalhes record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_config_tributaria = CustomConvertersExtensions.ConvertToInt32Validation(record.id_config_tributaria);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.preco_custo = CustomConvertersExtensions.ConvertToDecimalValidation(record.preco_custo);
            this.preco_venda = CustomConvertersExtensions.ConvertToDecimalValidation(record.preco_venda);
            this.custo_medio = CustomConvertersExtensions.ConvertToDecimalValidation(record.custo_medio);
            this.despesas1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.despesas1);
            this.qtde_minima = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_minima);
            this.qtde_maxima = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_maxima);
            this.ipi = CustomConvertersExtensions.ConvertToDecimalValidation(record.ipi);
            this.cnpj_emp = record.cnpj_emp;
            this.cod_barra = record.cod_barra;
            this.desc_config_tributaria = record.desc_config_tributaria;
            this.recordKey = $"[{record.cnpj_emp}]|[{record.cod_produto}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
