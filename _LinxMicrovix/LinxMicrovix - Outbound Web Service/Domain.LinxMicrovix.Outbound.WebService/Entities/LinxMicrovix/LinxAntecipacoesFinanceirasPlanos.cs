using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanos
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_antecipacoes_financeiras { get; private set; }

        [Column(TypeName = "int")]
        public Int32? numero_antecipacao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        public string? nome_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_ordservprod { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos_produtos_tmp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos { get; private set; }

        [Column(TypeName = "bit")]
        public bool? cancelado { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? previsao_entrega { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? numero_ficha { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos_produtos_campos_adicionais_tmp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_link_pagamento_linx_pay_hub { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_gerencial { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        public LinxAntecipacoesFinanceirasPlanos() { }

        public LinxAntecipacoesFinanceirasPlanos(
            string? portal,
            string? cnpj_emp,
            string? id_antecipacoes_financeiras,
            string? numero_antecipacao,
            string? forma_pgto,
            string? plano,
            string? nome_plano,
            string? valor,
            string? cancelado,
            string? timestamp,
            string? id_ordservprod,
            string? id_vendas_pos_produtos_tmp,
            string? id_vendas_pos,
            string? previsao_entrega,
            string? numero_ficha,
            string? id_vendas_pos_produtos_campos_adicionais_tmp,
            string? id_link_pagamento_linx_pay_hub,
            string? codigo_gerencial,
            string? empresa
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

            this.codigo_gerencial =
                codigo_gerencial == String.Empty ? ""
                : codigo_gerencial.Substring(
                    0,
                    codigo_gerencial.Length > 20 ? 20
                    : codigo_gerencial.Length
                );

            this.id_link_pagamento_linx_pay_hub =
                id_link_pagamento_linx_pay_hub == String.Empty ? 0
                : Convert.ToInt32(id_link_pagamento_linx_pay_hub);

            this.id_vendas_pos_produtos_campos_adicionais_tmp =
                id_vendas_pos_produtos_campos_adicionais_tmp == String.Empty ? 0
                : Convert.ToInt32(id_vendas_pos_produtos_campos_adicionais_tmp);

            this.numero_ficha =
                numero_ficha == String.Empty ? 0
                : Convert.ToInt64(numero_ficha);

            this.previsao_entrega =
                String.IsNullOrEmpty(previsao_entrega) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(previsao_entrega);

            this.id_ordservprod =
                id_ordservprod == String.Empty ? 0
                : Convert.ToInt32(id_ordservprod);

            this.id_vendas_pos_produtos_tmp =
                id_vendas_pos_produtos_tmp == String.Empty ? 0
                : Convert.ToInt32(id_vendas_pos_produtos_tmp);

            this.id_vendas_pos =
                id_vendas_pos == String.Empty ? 0
                : Convert.ToInt32(id_vendas_pos);

            this.id_antecipacoes_financeiras =
                id_antecipacoes_financeiras == String.Empty ? 0
                : Convert.ToInt32(id_antecipacoes_financeiras);

            this.numero_antecipacao =
                numero_antecipacao == String.Empty ? 0
                : Convert.ToInt32(numero_antecipacao);

            this.forma_pgto =
                forma_pgto == String.Empty ? ""
                : forma_pgto.Substring(
                    0,
                    forma_pgto.Length > 50 ? 50
                    : forma_pgto.Length
                );

            this.plano =
                plano == String.Empty ? 0
                : Convert.ToInt32(plano);

            this.nome_plano =
                nome_plano == String.Empty ? ""
                : nome_plano.Substring(
                    0,
                    nome_plano.Length > 35 ? 35
                    : nome_plano.Length
                );

            this.valor =
                valor == String.Empty ? 0
                : Convert.ToDecimal(valor);

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
