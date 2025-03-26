using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxProdutos", Schema = "linx_microvix_erp")]
    public class LinxProdutos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cod_barra { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? ncm { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? cest { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cod_auxiliar { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? unidade { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_cor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_tamanho { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_setor { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_linha { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_marca { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_colecao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_fornecedor { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? desativado { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_espessura { get; private set; }

        [Column(TypeName = "int")]
        public string? id_espessura { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_classificacao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_classificacao { get; private set; }

        [Column(TypeName = "int")]
        public string? origem_mercadoria { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? peso_liquido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? peso_bruto { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cor { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? id_tamanho { get; private set; }

        [Column(TypeName = "int")]
        public string? id_setor { get; private set; }

        [Column(TypeName = "int")]
        public string? id_linha { get; private set; }

        [Column(TypeName = "int")]
        public string? id_marca { get; private set; }

        [Column(TypeName = "int")]
        public string? id_colecao { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_inclusao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? fator_conversao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_reshop { get; private set; }

        [Column(TypeName = "int")]
        public string? id_produtos_opticos_tipo { get; private set; }

        [Column(TypeName = "int")]
        public string? id_sped_tipo_item { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? componente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? altura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? largura_para_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? comprimento_para_frete { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? loja_virtual { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_comprador { get; private set; }

        [Column(TypeName = "bit")]
        public string? obrigatorio_identificacao_cliente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao_basica { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? curva { get; private set; }
    }
}
