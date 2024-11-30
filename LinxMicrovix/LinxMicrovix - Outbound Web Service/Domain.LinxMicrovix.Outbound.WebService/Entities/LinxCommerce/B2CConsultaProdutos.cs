using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Domain.IntegrationsCore.CustomValidations;

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
                String.IsNullOrEmpty(cod_fornecedor) ? 0
                : Convert.ToInt32(cod_fornecedor);

            this.canais_ecommerce_publicados =
                String.IsNullOrEmpty(canais_ecommerce_publicados) ? 0
                : Convert.ToInt32(canais_ecommerce_publicados);

            this.inicio_publicacao_produto =
                String.IsNullOrEmpty(inicio_publicacao_produto) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(inicio_publicacao_produto);

            this.fim_publicacao_produto =
                String.IsNullOrEmpty(fim_publicacao_produto) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(fim_publicacao_produto);

            this.altura_para_frete =
                String.IsNullOrEmpty(altura_para_frete) ? 0
                : Convert.ToDecimal(altura_para_frete);

            this.largura_para_frete =
                String.IsNullOrEmpty(largura_para_frete) ? 0
                : Convert.ToDecimal(largura_para_frete);

            this.comprimento_para_frete =
                String.IsNullOrEmpty(comprimento_para_frete) ? 0
                : Convert.ToDecimal(comprimento_para_frete);

            this.peso_bruto =
                String.IsNullOrEmpty(peso_bruto) ? 0
                : Convert.ToDecimal(peso_bruto);

            this.descricao_completa_commerce =
                String.IsNullOrEmpty(descricao_completa_commerce) ? ""
                : descricao_completa_commerce.Substring(
                    0,
                    descricao_completa_commerce.Length > 8000 ? 8000
                    : descricao_completa_commerce.Length
                );

            this.codigo_integracao_oms =
                String.IsNullOrEmpty(codigo_integracao_oms) ? ""
                : codigo_integracao_oms.Substring(
                    0,
                    codigo_integracao_oms.Length > 50 ? 50
                    : codigo_integracao_oms.Length
                );

            this.dt_update =
                String.IsNullOrEmpty(dt_update) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_update);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.referencia =
                String.IsNullOrEmpty(referencia) ? ""
                : referencia.Substring(
                    0,
                    referencia.Length > 20 ? 20
                    : referencia.Length
                );

            this.codauxiliar1 =
                String.IsNullOrEmpty(codauxiliar1) ? ""
                : codauxiliar1.Substring(
                    0,
                    codauxiliar1.Length > 40 ? 40
                    : codauxiliar1.Length
                );

            this.descricao_basica =
                String.IsNullOrEmpty(descricao_basica) ? ""
                : descricao_basica.Substring(
                    0,
                    descricao_basica.Length > 100 ? 100
                    : descricao_basica.Length
                );

            this.nome_produto =
                String.IsNullOrEmpty(nome_produto) ? ""
                : nome_produto.Substring(
                    0,
                    nome_produto.Length > 250 ? 250
                    : nome_produto.Length
                );

            this.peso_liquido =
                String.IsNullOrEmpty(peso_liquido) ? 0
                : Convert.ToDecimal(peso_liquido);

            this.codigo_setor =
                String.IsNullOrEmpty(codigo_setor) ? 0
                : Convert.ToInt32(codigo_setor);

            this.codigo_linha =
                String.IsNullOrEmpty(codigo_linha) ? 0
                : Convert.ToInt32(codigo_linha);

            this.codigo_marca =
                String.IsNullOrEmpty(codigo_marca) ? 0
                : Convert.ToInt32(codigo_marca);

            this.codigo_colecao =
                String.IsNullOrEmpty(codigo_colecao) ? 0
                : Convert.ToInt32(codigo_colecao);

            this.codigo_espessura =
                String.IsNullOrEmpty(codigo_espessura) ? 0
                : Convert.ToInt32(codigo_espessura);

            this.codigo_grade1 =
                String.IsNullOrEmpty(codigo_grade1) ? 0
                : Convert.ToInt32(codigo_grade1);

            this.codigo_grade2 =
                String.IsNullOrEmpty(codigo_grade2) ? 0
                : Convert.ToInt32(codigo_grade2);

            this.unidade =
                String.IsNullOrEmpty(unidade) ? ""
                : unidade.Substring(
                    0,
                    unidade.Length > 50 ? 50
                    : unidade.Length
                );

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.codigo_classificacao =
                String.IsNullOrEmpty(codigo_classificacao) ? 0
                : Convert.ToInt32(codigo_classificacao);

            this.dt_cadastro =
                String.IsNullOrEmpty(dt_cadastro) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_cadastro);

            this.observacao =
                String.IsNullOrEmpty(observacao) ? ""
                : observacao;

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
