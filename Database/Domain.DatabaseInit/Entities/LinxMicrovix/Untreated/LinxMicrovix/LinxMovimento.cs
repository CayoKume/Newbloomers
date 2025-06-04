using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimento", Schema = "untreated")]
    public class LinxMovimento
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "int")]
        public string? usuario { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Key]
        [Column(TypeName = "varchar(44)")]
        public string? chave_nf { get; private set; }

        [Column(TypeName = "int")]
        public string? ecf { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? numero_serie_ecf { get; private set; }

        [Column(TypeName = "int")]
        public string? modelo_nf { get; private set; }

        [Key]
        [Column(TypeName = "datetime")]
        public string? data_documento { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_lancamento { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_cliente { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? desc_cfop { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? id_cfop { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_custo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_liquido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_icms { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_pis { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_cofins { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_ipi { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_pis { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_pis { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_pis { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_cofins { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_cofins { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_cofins { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_icms_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_icms_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_icms_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_ipi { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_ipi { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_ipi { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_total { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_dinheiro { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_dinheiro { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_cheque { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_cheque { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_cartao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_cartao { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_crediario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_crediario { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_convenio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_convenio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? frete { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? operacao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_transacao { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cod_barra { get; private set; }

        [Key]
        [Column(TypeName = "char(1)")]
        public string? cancelado { get; private set; }

        [Key]
        [Column(TypeName = "char(1)")]
        public string? excluido { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? soma_relatorio { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? deposito { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_unitario { get; private set; }

        [Column(TypeName = "char(5)")]
        public string? hora_lancamento { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? natureza_operacao { get; private set; }

        [Column(TypeName = "int")]
        public string? tabela_preco { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_tabela_preco { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_sefaz_situacao { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_sefaz_situacao { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? protocolo_aut_nfe { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_cheque_prazo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_cheque_prazo { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? cod_natureza_operacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_tabela_epoca { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_total_item { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? conferido { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? transacao_pedido_venda { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? codigo_modelo_nf { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acrescimo { get; private set; }

        [Column(TypeName = "bit")]
        public string? mob_checkout { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_iss { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_iss { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? ordem { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_rotina_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? troco { get; private set; }

        [Column(TypeName = "int")]
        public string? transportador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_aliquota_desonerado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_valor_desonerado_item { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_iss { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? iss_base_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? despesas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? seguro_total_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acrescimo_total_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? despesas_total_item { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_pix { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_pix { get; private set; }

        [Column(TypeName = "bit")]
        public string? forma_deposito_bancario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? total_deposito_bancario { get; private set; }

        [Column(TypeName = "int")]
        public string? id_venda_produto_b2c { get; private set; }

        [Column(TypeName = "bit")]
        public string? item_promocional { get; private set; }

        [Column(TypeName = "bit")]
        public string? acrescimo_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_aliquota { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_margem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_percentual_reducao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_valor_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_base_desonerado_item { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? codigo_status_nfe { get; private set; }
    }
}
