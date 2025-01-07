using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "referencia")]
        public string? referencia { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "codauxiliar1")]
        public string? codauxiliar1 { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "descricao_basica")]
        public string? descricao_basica { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "nome_produto")]
        public string? nome_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? peso_liquido { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_setor { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_linha { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_marca { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_colecao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_espessura { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_grade1 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_grade2 { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "unidade")]
        public string? unidade { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "int")]
        public Int32? codigo_classificacao { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_cadastro { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_fornecedor { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_update { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? altura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? largura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comprimento_para_frete { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? peso_bruto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(8000)")]
        [LengthValidation(length: 8000, propertyName: "descricao_completa_commerce")]
        public string? descricao_completa_commerce { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? canais_ecommerce_publicados { get; private set; }

        [Column(TypeName = "date")]
        public DateTime? inicio_publicacao_produto { get; private set; }

        [Column(TypeName = "date")]
        public DateTime? fim_publicacao_produto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_oms")]
        public string? codigo_integracao_oms { get; private set; }

        public B2CConsultaProdutos() { }

        public B2CConsultaProdutos(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? referencia,
            string? codauxiliar1,
            string? descricao_basica,
            string? nome_produto,
            string? peso_liquido,
            string? codigo_setor,
            string? codigo_linha,
            string? codigo_marca,
            string? codigo_colecao,
            string? codigo_espessura,
            string? codigo_grade1,
            string? codigo_grade2,
            string? unidade,
            string? ativo,
            string? codigo_classificacao,
            string? dt_cadastro,
            string? observacao,
            string? cod_fornecedor,
            string? dt_update,
            string? altura_para_frete,
            string? largura_para_frete,
            string? comprimento_para_frete,
            string? timestamp,
            string? peso_bruto,
            string? portal,
            string? descricao_completa_commerce,
            string? canais_ecommerce_publicados,
            string? inicio_publicacao_produto,
            string? fim_publicacao_produto,
            string? codigo_integracao_oms
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_fornecedor =
                ConvertToInt32Validation.IsValid(cod_fornecedor, "cod_fornecedor", listValidations) ?
                Convert.ToInt32(cod_fornecedor) :
                0;

            this.canais_ecommerce_publicados =
                ConvertToInt32Validation.IsValid(canais_ecommerce_publicados, "canais_ecommerce_publicados", listValidations) ?
                Convert.ToInt32(canais_ecommerce_publicados) :
                0;

            this.inicio_publicacao_produto =
                ConvertToDateTimeValidation.IsValid(inicio_publicacao_produto, "inicio_publicacao_produto", listValidations) ?
                Convert.ToDateTime(inicio_publicacao_produto) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.fim_publicacao_produto =
                ConvertToDateTimeValidation.IsValid(fim_publicacao_produto, "fim_publicacao_produto", listValidations) ?
                Convert.ToDateTime(fim_publicacao_produto) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.altura_para_frete =
                ConvertToDecimalValidation.IsValid(altura_para_frete, "altura_para_frete", listValidations) ?
                Convert.ToDecimal(altura_para_frete) :
                0;

            this.largura_para_frete =
                ConvertToDecimalValidation.IsValid(largura_para_frete, "largura_para_frete", listValidations) ?
                Convert.ToDecimal(largura_para_frete) :
                0;

            this.comprimento_para_frete =
                ConvertToDecimalValidation.IsValid(comprimento_para_frete, "comprimento_para_frete", listValidations) ?
                Convert.ToDecimal(comprimento_para_frete) :
                0;

            this.peso_bruto =
                ConvertToDecimalValidation.IsValid(peso_bruto, "peso_bruto", listValidations) ?
                Convert.ToDecimal(peso_bruto) :
                0;

            this.dt_update =
                ConvertToDateTimeValidation.IsValid(dt_update, "dt_update", listValidations) ?
                Convert.ToDateTime(dt_update) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.peso_liquido =
                ConvertToDecimalValidation.IsValid(peso_liquido, "peso_liquido", listValidations) ?
                Convert.ToDecimal(peso_liquido) :
                0;

            this.codigo_setor =
                ConvertToInt32Validation.IsValid(codigo_setor, "codigo_setor", listValidations) ?
                Convert.ToInt32(codigo_setor) :
                0;

            this.codigo_linha =
                ConvertToInt32Validation.IsValid(codigo_linha, "codigo_linha", listValidations) ?
                Convert.ToInt32(codigo_linha) :
                0;

            this.codigo_marca =
                ConvertToInt32Validation.IsValid(codigo_marca, "codigo_marca", listValidations) ?
                Convert.ToInt32(codigo_marca) :
                0;

            this.codigo_colecao =
                ConvertToInt32Validation.IsValid(codigo_colecao, "codigo_colecao", listValidations) ?
                Convert.ToInt32(codigo_colecao) :
                0;

            this.codigo_espessura =
                ConvertToInt32Validation.IsValid(codigo_espessura, "codigo_espessura", listValidations) ?
                Convert.ToInt32(codigo_espessura) :
                0;

            this.codigo_grade1 =
                ConvertToInt32Validation.IsValid(codigo_grade1, "codigo_grade1", listValidations) ?
                Convert.ToInt32(codigo_grade1) :
                0;

            this.codigo_grade2 =
                ConvertToInt32Validation.IsValid(codigo_grade2, "codigo_grade2", listValidations) ?
                Convert.ToInt32(codigo_grade2) :
                0;

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.codigo_classificacao =
                ConvertToInt32Validation.IsValid(codigo_classificacao, "codigo_classificacao", listValidations) ?
                Convert.ToInt32(codigo_classificacao) :
                0;

            this.dt_cadastro =
                ConvertToDateTimeValidation.IsValid(dt_cadastro, "dt_cadastro", listValidations) ?
                Convert.ToDateTime(dt_cadastro) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.unidade = unidade;
            this.observacao = observacao;
            this.referencia = referencia;
            this.codauxiliar1 = codauxiliar1;
            this.descricao_basica = descricao_basica;
            this.nome_produto = nome_produto;
            this.descricao_completa_commerce = descricao_completa_commerce;
            this.codigo_integracao_oms = codigo_integracao_oms;
        }
    }
}
