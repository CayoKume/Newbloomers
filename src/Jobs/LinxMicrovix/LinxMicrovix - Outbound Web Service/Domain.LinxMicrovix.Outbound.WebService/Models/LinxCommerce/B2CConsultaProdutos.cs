
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public string? referencia { get; private set; }
        public string? codauxiliar1 { get; private set; }
        public string? descricao_basica { get; private set; }
        public string? nome_produto { get; private set; }
        public decimal? peso_liquido { get; private set; }
        public Int32? codigo_setor { get; private set; }
        public Int32? codigo_linha { get; private set; }
        public Int32? codigo_marca { get; private set; }
        public Int32? codigo_colecao { get; private set; }
        public Int32? codigo_espessura { get; private set; }
        public Int32? codigo_grade1 { get; private set; }
        public Int32? codigo_grade2 { get; private set; }
        public string? unidade { get; private set; }
        public Int32? ativo { get; private set; }
        public Int32? codigo_classificacao { get; private set; }
        public DateTime? dt_cadastro { get; private set; }
        public string? observacao { get; private set; }
        public Int32? cod_fornecedor { get; private set; }
        public DateTime? dt_update { get; private set; }
        public decimal? altura_para_frete { get; private set; }
        public decimal? largura_para_frete { get; private set; }
        public decimal? comprimento_para_frete { get; private set; }
        public Int64? timestamp { get; private set; }
        public decimal? peso_bruto { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao_completa_commerce { get; private set; }
        public Int32? canais_ecommerce_publicados { get; private set; }
        public DateTime? inicio_publicacao_produto { get; private set; }
        public DateTime? fim_publicacao_produto { get; private set; }
        public string? codigo_integracao_oms { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutos() { }

        public B2CConsultaProdutos(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutos record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

            this.cod_fornecedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_fornecedor);
            this.canais_ecommerce_publicados = CustomConvertersExtensions.ConvertToInt32Validation(record.canais_ecommerce_publicados);
            this.inicio_publicacao_produto = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.inicio_publicacao_produto);
            this.fim_publicacao_produto = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.fim_publicacao_produto);
            this.altura_para_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.altura_para_frete);
            this.largura_para_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.largura_para_frete);
            this.comprimento_para_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.comprimento_para_frete);
            this.peso_bruto = CustomConvertersExtensions.ConvertToDecimalValidation(record.peso_bruto);
            this.dt_update = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_update);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt32Validation(record.codigoproduto);
            this.peso_liquido = CustomConvertersExtensions.ConvertToDecimalValidation(record.peso_liquido);
            this.codigo_setor = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_setor);
            this.codigo_linha = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_linha);
            this.codigo_marca = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_marca);
            this.codigo_colecao = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_colecao);
            this.codigo_espessura = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_espessura);
            this.codigo_grade1 = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_grade1);
            this.codigo_grade2 = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_grade2);
            this.ativo = CustomConvertersExtensions.ConvertToInt32Validation(record.ativo);
            this.codigo_classificacao = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_classificacao);
            this.dt_cadastro = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_cadastro);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.unidade = record.unidade;
            this.observacao = record.observacao;
            this.referencia = record.referencia;
            this.codauxiliar1 = record.codauxiliar1;
            this.descricao_basica = record.descricao_basica;
            this.nome_produto = record.nome_produto;
            this.descricao_completa_commerce = record.descricao_completa_commerce;
            this.codigo_integracao_oms = record.codigo_integracao_oms;
            this.recordXml = recordXml;
        }
    }
}
