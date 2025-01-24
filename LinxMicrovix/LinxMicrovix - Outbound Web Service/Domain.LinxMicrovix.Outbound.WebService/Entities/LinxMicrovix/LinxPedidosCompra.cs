using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxPedidosCompra", Schema = "linx_microvix_erp")]
    public class LinxPedidosCompra
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
        public DateTime? data_pedido { get; private set; }

        [Column(TypeName = "int")]
        public Int32? transacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? usuario { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_fornecedor { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_produto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_unitario { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_comprador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_total { get; private set; }

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
        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "encerrado")]
        public string? encerrado { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_aprovacao { get; private set; }

        [Column(TypeName = "varchar(15)")]
        [LengthValidation(length: 15, propertyName: "numero_ped_fornec")]
        public string? numero_ped_fornec { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_frete")]
        public string? tipo_frete { get; private set; }

        [Column(TypeName = "varchar(73)")]
        [LengthValidation(length: 73, propertyName: "natureza_operacao")]
        public string? natureza_operacao { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? previsao_entrega { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "numero_projeto_officina")]
        public string? numero_projeto_officina { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "status_pedido")]
        public string? status_pedido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_entregue { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "descricao_frete")]
        public string? descricao_frete { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? integrado_linx { get; private set; }

        [Column(TypeName = "int")]
        public Int32? nf_gerada { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "nf_origem_ws")]
        public string? nf_origem_ws { get; private set; }

        public LinxPedidosCompra() { }

        public LinxPedidosCompra(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_pedido,
            string? data_pedido,
            string? transacao,
            string? usuario,
            string? codigo_fornecedor,
            string? cod_produto,
            string? quantidade,
            string? valor_unitario,
            string? cod_comprador,
            string? valor_frete,
            string? valor_total,
            string? cod_plano_pagamento,
            string? plano_pagamento,
            string? obs,
            string? aprovado,
            string? cancelado,
            string? encerrado,
            string? data_aprovacao,
            string? numero_ped_fornec,
            string? tipo_frete,
            string? natureza_operacao,
            string? previsao_entrega,
            string? numero_projeto_officina,
            string? status_pedido,
            string? qtde_entregue,
            string? descricao_frete,
            string? integrado_linx,
            string? nf_gerada,
            string? timestamp,
            string? empresa,
            string? nf_origem_ws
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_pedido =
                ConvertToInt32Validation.IsValid(cod_pedido, "cod_pedido", listValidations) ?
                Convert.ToInt32(cod_pedido) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.usuario =
                ConvertToInt32Validation.IsValid(usuario, "usuario", listValidations) ?
                Convert.ToInt32(usuario) :
                0;

            this.codigo_fornecedor =
                ConvertToInt32Validation.IsValid(codigo_fornecedor, "codigo_fornecedor", listValidations) ?
                Convert.ToInt32(codigo_fornecedor) :
                0;

            this.cod_comprador =
                ConvertToInt32Validation.IsValid(cod_comprador, "cod_comprador", listValidations) ?
                Convert.ToInt32(cod_comprador) :
                0;

            this.cod_plano_pagamento =
                ConvertToInt32Validation.IsValid(cod_plano_pagamento, "cod_plano_pagamento", listValidations) ?
                Convert.ToInt32(cod_plano_pagamento) :
                0;

            this.nf_gerada =
                ConvertToInt32Validation.IsValid(nf_gerada, "nf_gerada", listValidations) ?
                Convert.ToInt32(nf_gerada) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.data_pedido =
                ConvertToDateTimeValidation.IsValid(data_pedido, "data_pedido", listValidations) ?
                Convert.ToDateTime(data_pedido) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_aprovacao =
                ConvertToDateTimeValidation.IsValid(data_aprovacao, "data_aprovacao", listValidations) ?
                Convert.ToDateTime(data_aprovacao) :
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

            this.qtde_entregue =
                ConvertToDecimalValidation.IsValid(qtde_entregue, "qtde_entregue", listValidations) ?
                Convert.ToDecimal(qtde_entregue, new CultureInfo("en-US")) :
                0;

            this.integrado_linx =
                ConvertToInt32Validation.IsValid(integrado_linx, "integrado_linx", listValidations) ?
                Convert.ToInt32(integrado_linx) :
                0;

            this.status_pedido = status_pedido;
            this.tipo_frete = tipo_frete;
            this.nf_origem_ws = nf_origem_ws;
            this.descricao_frete = descricao_frete;
            this.numero_projeto_officina = numero_projeto_officina;
            this.natureza_operacao = natureza_operacao;
            this.numero_ped_fornec = numero_ped_fornec;
            this.encerrado = encerrado;
            this.aprovado = aprovado;
            this.cancelado = cancelado;
            this.obs = obs;
            this.plano_pagamento = plano_pagamento;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
