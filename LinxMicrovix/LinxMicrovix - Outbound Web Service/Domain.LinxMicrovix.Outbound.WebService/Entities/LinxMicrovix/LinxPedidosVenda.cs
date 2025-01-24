using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxPedidosVenda", Schema = "linx_microvix_erp")]
    public class LinxPedidosVenda
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_pedido { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_lancamento { get; private set; }

        [Column(TypeName = "char(5)")]
        [LengthValidation(length: 5, propertyName: "hora_lancamento")]
        public string? hora_lancamento { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? usuario { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_cliente { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_unitario { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_total { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto_item { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(35)")]
        [LengthValidation(length: 35, propertyName: "plano_pagamento")]
        public string? plano_pagamento { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "aprovado")]
        public string? aprovado { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "cancelado {")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_aprovacao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_alteracao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? tipo_frete { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "natureza_operacao")]
        public string? natureza_operacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? tabela_preco { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_tabela_preco")]
        public string? nome_tabela_preco { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? previsao_entrega { get; private set; }

        [Column(TypeName = "int")]
        public Int32? realizado_por { get; private set; }

        [Column(TypeName = "int")]
        public Int32? pontuacao_ser { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "venda_externa")]
        public string? venda_externa { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? nf_gerada { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "status")]
        public string? status { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "numero_projeto_officina")]
        public string? numero_projeto_officina { get; private set; }

        [Column(TypeName = "char(10)")]
        [LengthValidation(length: 10, propertyName: "cod_natureza_operacao")]
        public string? cod_natureza_operacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? margem_contribuicao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? doc_origem { get; private set; }

        [Column(TypeName = "int")]
        public Int32? posicao_item { get; private set; }

        [Column(TypeName = "int")]
        public Int32? orcamento_origem { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao_ws { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? transportador { get; private set; }

        [Column(TypeName = "int")]
        public Int32? deposito { get; private set; }

        public LinxPedidosVenda() { }

        public LinxPedidosVenda(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_pedido,
            string? data_lancamento,
            string? hora_lancamento,
            string? transacao,
            string? usuario,
            string? codigo_cliente,
            string? cod_produto,
            string? quantidade,
            string? valor_unitario,
            string? cod_vendedor,
            string? valor_frete,
            string? valor_total,
            string? desconto_item,
            string? cod_plano_pagamento,
            string? plano_pagamento,
            string? obs,
            string? aprovado,
            string? cancelado,
            string? data_aprovacao,
            string? data_alteracao,
            string? tipo_frete,
            string? natureza_operacao,
            string? tabela_preco,
            string? nome_tabela_preco,
            string? previsao_entrega,
            string? realizado_por,
            string? pontuacao_ser,
            string? venda_externa,
            string? nf_gerada,
            string? status,
            string? numero_projeto_officina,
            string? cod_natureza_operacao,
            string? margem_contribuicao,
            string? doc_origem,
            string? posicao_item,
            string? orcamento_origem,
            string? transacao_origem,
            string? timestamp,
            string? desconto,
            string? transacao_ws,
            string? empresa,
            string? transportador,
            string? deposito
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.usuario =
                ConvertToInt32Validation.IsValid(usuario, "usuario", listValidations) ?
                Convert.ToInt32(usuario) :
                0;

            this.codigo_cliente =
                ConvertToInt32Validation.IsValid(codigo_cliente, "codigo_cliente", listValidations) ?
                Convert.ToInt32(codigo_cliente) :
                0;

            this.cod_pedido =
                ConvertToInt32Validation.IsValid(cod_pedido, "cod_pedido", listValidations) ?
                Convert.ToInt32(cod_pedido) :
                0;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.cod_plano_pagamento =
                ConvertToInt32Validation.IsValid(cod_plano_pagamento, "cod_plano_pagamento", listValidations) ?
                Convert.ToInt32(cod_plano_pagamento) :
                0;

            this.tipo_frete =
                ConvertToInt32Validation.IsValid(tipo_frete, "tipo_frete", listValidations) ?
                Convert.ToInt32(tipo_frete) :
                0;

            this.tabela_preco =
                ConvertToInt32Validation.IsValid(tabela_preco, "tabela_preco", listValidations) ?
                Convert.ToInt32(tabela_preco) :
                0;

            this.realizado_por =
                ConvertToInt32Validation.IsValid(realizado_por, "realizado_por", listValidations) ?
                Convert.ToInt32(realizado_por) :
                0;

            this.pontuacao_ser =
                ConvertToInt32Validation.IsValid(pontuacao_ser, "pontuacao_ser", listValidations) ?
                Convert.ToInt32(pontuacao_ser) :
                0;

            this.doc_origem =
                ConvertToInt32Validation.IsValid(doc_origem, "doc_origem", listValidations) ?
                Convert.ToInt32(doc_origem) :
                0;

            this.posicao_item =
                ConvertToInt32Validation.IsValid(posicao_item, "posicao_item", listValidations) ?
                Convert.ToInt32(posicao_item) :
                0;

            this.orcamento_origem =
                ConvertToInt32Validation.IsValid(orcamento_origem, "orcamento_origem", listValidations) ?
                Convert.ToInt32(orcamento_origem) :
                0;

            this.transacao_origem =
                ConvertToInt32Validation.IsValid(transacao_origem, "transacao_origem", listValidations) ?
                Convert.ToInt32(transacao_origem) :
                0;

            this.transacao_ws =
                ConvertToInt32Validation.IsValid(transacao_ws, "transacao_ws", listValidations) ?
                Convert.ToInt32(transacao_ws) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.deposito =
                ConvertToInt32Validation.IsValid(deposito, "deposito", listValidations) ?
                Convert.ToInt32(deposito) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.transportador =
                ConvertToInt64Validation.IsValid(transportador, "transportador", listValidations) ?
                Convert.ToInt64(transportador) :
                0;

            this.data_lancamento =
                ConvertToDateTimeValidation.IsValid(data_lancamento, "data_lancamento", listValidations) ?
                Convert.ToDateTime(data_lancamento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_aprovacao =
                ConvertToDateTimeValidation.IsValid(data_aprovacao, "data_aprovacao", listValidations) ?
                Convert.ToDateTime(data_aprovacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_alteracao =
                ConvertToDateTimeValidation.IsValid(data_alteracao, "data_alteracao", listValidations) ?
                Convert.ToDateTime(data_alteracao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.previsao_entrega =
                ConvertToDateTimeValidation.IsValid(previsao_entrega, "previsao_entrega", listValidations) ?
                Convert.ToDateTime(previsao_entrega) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
                0;

            this.valor_unitario =
                ConvertToDecimalValidation.IsValid(valor_unitario, "valor_unitario", listValidations) ?
                Convert.ToDecimal(valor_unitario, new CultureInfo("en-US")) :
                0;

            this.valor_frete =
                ConvertToDecimalValidation.IsValid(valor_frete, "valor_frete", listValidations) ?
                Convert.ToDecimal(valor_frete, new CultureInfo("en-US")) :
                0;

            this.valor_total =
                ConvertToDecimalValidation.IsValid(valor_total, "valor_total", listValidations) ?
                Convert.ToDecimal(valor_total, new CultureInfo("en-US")) :
                0;

            this.desconto_item =
                ConvertToDecimalValidation.IsValid(desconto_item, "desconto_item", listValidations) ?
                Convert.ToDecimal(desconto_item, new CultureInfo("en-US")) :
                0;

            this.margem_contribuicao =
                ConvertToDecimalValidation.IsValid(margem_contribuicao, "margem_contribuicao", listValidations) ?
                Convert.ToDecimal(margem_contribuicao, new CultureInfo("en-US")) :
                0;

            this.desconto =
                ConvertToDecimalValidation.IsValid(desconto, "desconto", listValidations) ?
                Convert.ToDecimal(desconto, new CultureInfo("en-US")) :
                0;

            this.cod_natureza_operacao = cod_natureza_operacao;
            this.numero_projeto_officina = numero_projeto_officina;
            this.status = status;
            this.nf_gerada = nf_gerada;
            this.venda_externa = venda_externa;
            this.nome_tabela_preco = nome_tabela_preco;
            this.natureza_operacao = natureza_operacao;
            this.aprovado = aprovado;
            this.cancelado = cancelado;
            this.obs = obs;
            this.plano_pagamento = plano_pagamento;
            this.hora_lancamento = hora_lancamento;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
