using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxClientesRede", Schema = "untreated")]
    public class LinxClientesRede
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_clientes_rede { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_razao_social { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_cadastro { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? pf_pj { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade { get; private set; }

        [Column(TypeName = "varchar(2)")]
        public string? uf { get; private set; }

        [Column(TypeName = "varchar(80)")]
        public string? pais { get; private set; }

        [Column(TypeName = "int")]
        public string? id_estado_civil { get; private set; }

        [Column(TypeName = "bit")]
        public string? compras_a_prazo { get; private set; }

        [Column(TypeName = "bit")]
        public string? aceita_boleto_bancario { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_fantasia { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_endereco { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? complemento { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro { get; private set; }

        [Column(TypeName = "varchar(9)")]
        public string? cep { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? telefone { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? celular { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? fax { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? site { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_nascimento { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? naturalidade { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sexo { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_pai { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_mae { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? identidade_cliente { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_emissao_identidade_cliente { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf_emissao_identidade_cliente { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? orgao_emissao_identidade_cliente { get; private set; }

        [Column(TypeName = "varchar(500)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_empresa_titular { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? telefone_empresa_titular { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? funcao_titular { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? tempo_servico_titular { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? renda_titular { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? inscricao_estadual { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? inscricao_municipal { get; private set; }

        [Column(TypeName = "bit")]
        public string? cliente_optante_simples_municipal { get; private set; }

        [Column(TypeName = "bit")]
        public string? cliente_optante_simples_federal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? limite_compras { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cartao_fidelidade { get; private set; }

        [Column(TypeName = "bit")]
        public string? desabilitado { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? motivo_bloqueio { get; private set; }

        [Column(TypeName = "int")]
        public string? portal_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente_portal_origem { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "bit")]
        public string? integrado_ws { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
