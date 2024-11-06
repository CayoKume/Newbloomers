using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix
{
    public class LinxAntecipacoesFinanceiras
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_cliente { get; private set; }

        [Column(TypeName = "int")]
        public Int32? numero_antecipacao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_antecipacao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? previsao_entrega { get; private set; }

        [Column(TypeName = "char(3)")]
        public string? dav_pv { get; private set; }

        [Column(TypeName = "int")]
        public Int32? numero_origem { get; private set; }

        [Column(TypeName = "int")]
        public Int32? dav_remessa { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? quantidade { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? preco_unitario_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_pago_antecipacao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? entregue { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public bool? cancelado { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_antecipacoes_financeiras { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_antecipacoes_financeiras_detalhes { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos_produtos { get; private set; }

        public LinxAntecipacoesFinanceiras() { }

        public LinxAntecipacoesFinanceiras(
            string? portal,
            string? cnpj_emp,
            string? empresa,
            string? cod_cliente,
            string? numero_antecipacao,
            string? data_antecipacao,
            string? previsao_entrega,
            string? dav_pv,
            string? numero_origem,
            string? dav_remessa,
            string? codigoproduto,
            string? quantidade,
            string? preco_unitario_produto,
            string? valor_pago_antecipacao,
            string? entregue,
            string? identificador,
            string? timestamp,
            string? cancelado,
            string? id_antecipacoes_financeiras,
            string? id_antecipacoes_financeiras_detalhes,
            string? id_vendas_pos_produtos
        )
        {
            this.lastupdateon = DateTime.Now;

            this.cnpj_emp =
                cnpj_emp == String.Empty ? ""
                : cnpj_emp.Substring(
                    0,
                    cnpj_emp.Length > 14 ? 14
                    : cnpj_emp.Length
                );

            this.empresa =
                empresa == String.Empty ? 0
                : Convert.ToInt32(empresa);

            this.id_antecipacoes_financeiras =
                id_antecipacoes_financeiras == String.Empty ? 0
                : Convert.ToInt32(id_antecipacoes_financeiras);

            this.id_antecipacoes_financeiras_detalhes =
                id_antecipacoes_financeiras_detalhes == String.Empty ? 0
                : Convert.ToInt32(id_antecipacoes_financeiras_detalhes);

            this.id_vendas_pos_produtos =
                id_vendas_pos_produtos == String.Empty ? 0
                : Convert.ToInt32(id_vendas_pos_produtos);

            this.cod_cliente =
                cod_cliente == String.Empty ? 0
                : Convert.ToInt32(cod_cliente);

            this.numero_antecipacao =
                numero_antecipacao == String.Empty ? 0
                : Convert.ToInt32(numero_antecipacao);

            this.data_antecipacao =
                String.IsNullOrEmpty(data_antecipacao) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_antecipacao);

            this.previsao_entrega =
                String.IsNullOrEmpty(previsao_entrega) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(previsao_entrega);

            this.dav_remessa =
                dav_remessa == String.Empty ? 0
                : Convert.ToInt32(dav_remessa);

            this.codigoproduto =
                codigoproduto == String.Empty ? 0
                : Convert.ToInt64(codigoproduto);

            this.quantidade =
                quantidade == String.Empty ? 0
                : Convert.ToDecimal(quantidade);

            this.preco_unitario_produto =
                preco_unitario_produto == String.Empty ? 0
                : Convert.ToDecimal(preco_unitario_produto);

            this.valor_pago_antecipacao =
                valor_pago_antecipacao == String.Empty ? 0
                : Convert.ToDecimal(valor_pago_antecipacao);

            this.entregue =
                entregue == String.Empty ? ""
                : entregue.Substring(
                    0,
                    entregue.Length > 1 ? 1
                    : entregue.Length
                );

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.cancelado =
                String.IsNullOrEmpty(cancelado) ? false
                : Convert.ToBoolean(cancelado);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
