using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutos", Schema = "linx_microvix_erp")]
    public class LinxProdutos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_produto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cod_barra")]
        public string? cod_barra { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "nome")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "ncm")]
        public string? ncm { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "cest")]
        public string? cest { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "referencia")]
        public string? referencia { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "cod_auxiliar")]
        public string? cod_auxiliar { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "unidade")]
        public string? unidade { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_cor")]
        public string? desc_cor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_tamanho")]
        public string? desc_tamanho { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_setor")]
        public string? desc_setor { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_linha")]
        public string? desc_linha { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_marca")]
        public string? desc_marca { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_colecao")]
        public string? desc_colecao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? dt_update { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_fornecedor { get; private set; }

        [Column(TypeName = "char(10)")]
        [LengthValidation(length: 10, propertyName: "desativado")]
        public string? desativado { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_espessura")]
        public string? desc_espessura { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_espessura { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_classificacao")]
        public string? desc_classificacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_classificacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? origem_mercadoria { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? peso_liquido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? peso_bruto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_cor { get; private set; }

        [Column(TypeName = "varchar(5)")]
        [LengthValidation(length: 5, propertyName: "id_tamanho")]
        public string? id_tamanho { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_setor { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_linha { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_marca { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_colecao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? dt_inclusao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? fator_conversao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_reshop")]
        public string? codigo_integracao_reshop { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_produtos_opticos_tipo { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_sped_tipo_item { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "componente")]
        public string? componente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? altura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? largura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comprimento_para_frete { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "loja_virtual")]
        public string? loja_virtual { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_comprador { get; private set; }

        [Column(TypeName = "bit")]
        public bool? obrigatorio_identificacao_cliente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "descricao_basica")]
        public string? descricao_basica { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "curva")]
        public string? curva { get; private set; }

        public LinxProdutos() { }

        public LinxProdutos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_produto,
            string? cod_barra,
            string? nome,
            string? ncm,
            string? cest,
            string? referencia,
            string? cod_auxiliar,
            string? unidade,
            string? desc_cor,
            string? desc_tamanho,
            string? desc_setor,
            string? desc_linha,
            string? desc_marca,
            string? desc_colecao,
            string? dt_update,
            string? cod_fornecedor,
            string? desativado,
            string? desc_espessura,
            string? id_espessura,
            string? desc_classificacao,
            string? id_classificacao,
            string? origem_mercadoria,
            string? peso_liquido,
            string? peso_bruto,
            string? id_cor,
            string? id_tamanho,
            string? id_setor,
            string? id_linha,
            string? id_marca,
            string? id_colecao,
            string? dt_inclusao,
            string? timestamp,
            string? fator_conversao,
            string? codigo_integracao_ws,
            string? codigo_integracao_reshop,
            string? id_produtos_opticos_tipo,
            string? id_sped_tipo_item,
            string? componente,
            string? altura_para_frete,
            string? largura_para_frete,
            string? comprimento_para_frete,
            string? loja_virtual,
            string? cod_comprador,
            string? obrigatorio_identificacao_cliente,
            string? descricao_basica,
            string? curva
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_fornecedor =
                ConvertToInt32Validation.IsValid(cod_fornecedor, "cod_fornecedor", listValidations) ?
                Convert.ToInt32(cod_fornecedor) :
                0;

            this.id_espessura =
                ConvertToInt32Validation.IsValid(id_espessura, "id_espessura", listValidations) ?
                Convert.ToInt32(id_espessura) :
                0;

            this.id_classificacao =
                ConvertToInt32Validation.IsValid(id_classificacao, "id_classificacao", listValidations) ?
                Convert.ToInt32(id_classificacao) :
                0;

            this.origem_mercadoria =
                ConvertToInt32Validation.IsValid(origem_mercadoria, "origem_mercadoria", listValidations) ?
                Convert.ToInt32(origem_mercadoria) :
                0;

            this.id_cor =
                ConvertToInt32Validation.IsValid(id_cor, "id_cor", listValidations) ?
                Convert.ToInt32(id_cor) :
                0;

            this.id_setor =
                ConvertToInt32Validation.IsValid(id_setor, "id_setor", listValidations) ?
                Convert.ToInt32(id_setor) :
                0;

            this.id_linha =
                ConvertToInt32Validation.IsValid(id_linha, "id_linha", listValidations) ?
                Convert.ToInt32(id_linha) :
                0;

            this.id_marca =
                ConvertToInt32Validation.IsValid(id_marca, "id_marca", listValidations) ?
                Convert.ToInt32(id_marca) :
                0;

            this.id_colecao =
                ConvertToInt32Validation.IsValid(id_colecao, "id_colecao", listValidations) ?
                Convert.ToInt32(id_colecao) :
                0;

            this.id_produtos_opticos_tipo =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_tipo, "id_produtos_opticos_tipo", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_tipo) :
                0;

            this.id_sped_tipo_item =
                ConvertToInt32Validation.IsValid(id_sped_tipo_item, "id_sped_tipo_item", listValidations) ?
                Convert.ToInt32(id_sped_tipo_item) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.dt_update =
                ConvertToDateTimeValidation.IsValid(dt_update, "dt_update", listValidations) ?
                Convert.ToDateTime(dt_update) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.peso_liquido =
                ConvertToDecimalValidation.IsValid(peso_liquido, "peso_liquido", listValidations) ?
                Convert.ToDecimal(peso_liquido) :
                0;

            this.peso_bruto =
                ConvertToDecimalValidation.IsValid(peso_bruto, "peso_bruto", listValidations) ?
                Convert.ToDecimal(peso_bruto) :
                0;

            this.fator_conversao =
                ConvertToDecimalValidation.IsValid(fator_conversao, "fator_conversao", listValidations) ?
                Convert.ToDecimal(fator_conversao) :
                0;

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

            this.obrigatorio_identificacao_cliente =
                ConvertToBooleanValidation.IsValid(obrigatorio_identificacao_cliente, "obrigatorio_identificacao_cliente", listValidations) ?
                Convert.ToBoolean(obrigatorio_identificacao_cliente) :
                false;

            this.curva = curva;
            this.descricao_basica = descricao_basica;
            this.loja_virtual = loja_virtual;
            this.componente = componente;
            this.codigo_integracao_reshop = codigo_integracao_reshop;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.id_tamanho = id_tamanho;
            this.desc_classificacao = desc_classificacao;
            this.desc_espessura = desc_espessura;
            this.desativado = desativado;
            this.desc_colecao = desc_colecao;
            this.desc_marca = desc_marca;
            this.desc_linha = desc_linha;
            this.desc_setor = desc_setor;
            this.desc_tamanho = desc_tamanho;
            this.desc_cor = desc_cor;
            this.unidade = unidade;
            this.cod_auxiliar = cod_auxiliar;
            this.referencia = referencia;
            this.cest = cest;
            this.ncm = ncm;
            this.nome = nome;
            this.cod_barra = cod_barra;
        }
    }
}
