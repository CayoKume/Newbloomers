using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaClientesEnderecosEntrega
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_endereco_entrega { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_b2c { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_rua_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? complemento_end_cli { get; private set; }

        [Column(TypeName = "char(9)")]
        public string? cep_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro_cliente { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade_cliente { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? principal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_cidade { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClientesEnderecosEntrega() { }

        public B2CConsultaClientesEnderecosEntrega(
            string? id_endereco_entrega,
            string? cod_cliente_erp,
            string? cod_cliente_b2c,
            string? endereco_cliente,
            string? numero_rua_cliente,
            string? complemento_end_cli,
            string? cep_cliente,
            string? bairro_cliente,
            string? cidade_cliente,
            string? uf_cliente,
            string? descricao,
            string? principal,
            string? id_cidade,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_endereco_entrega =
                String.IsNullOrEmpty(id_endereco_entrega) ? 0
                : Convert.ToInt32(id_endereco_entrega);

            this.cod_cliente_erp =
                String.IsNullOrEmpty(cod_cliente_erp) ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.cod_cliente_b2c =
                String.IsNullOrEmpty(cod_cliente_b2c) ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.endereco_cliente =
                String.IsNullOrEmpty(endereco_cliente) ? ""
                : endereco_cliente.Substring(
                    0,
                    endereco_cliente.Length > 250 ? 250
                    : endereco_cliente.Length
                );

            this.numero_rua_cliente =
                String.IsNullOrEmpty(numero_rua_cliente) ? ""
                : numero_rua_cliente.Substring(
                    0,
                    numero_rua_cliente.Length > 20 ? 20
                    : numero_rua_cliente.Length
                );

            this.complemento_end_cli =
                String.IsNullOrEmpty(complemento_end_cli) ? ""
                : complemento_end_cli.Substring(
                    0,
                    complemento_end_cli.Length > 60 ? 60
                    : complemento_end_cli.Length
                );

            this.cep_cliente =
                String.IsNullOrEmpty(cep_cliente) ? ""
                : cep_cliente.Substring(
                    0,
                    cep_cliente.Length > 9 ? 9
                    : cep_cliente.Length
                );

            this.bairro_cliente =
                String.IsNullOrEmpty(bairro_cliente) ? ""
                : bairro_cliente.Substring(
                    0,
                    bairro_cliente.Length > 60 ? 60
                    : bairro_cliente.Length
                );

            this.cidade_cliente =
                String.IsNullOrEmpty(cidade_cliente) ? ""
                : cidade_cliente.Substring(
                    0,
                    cidade_cliente.Length > 40 ? 40
                    : cidade_cliente.Length
                );

            this.uf_cliente =
                String.IsNullOrEmpty(uf_cliente) ? ""
                : uf_cliente.Substring(
                    0,
                    uf_cliente.Length > 2 ? 2
                    : uf_cliente.Length
                );

            this.descricao =
                String.IsNullOrEmpty(descricao) ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 250 ? 250
                    : descricao.Length
                );

            this.principal =
                String.IsNullOrEmpty(principal) ? 0
                : Convert.ToInt32(principal);

            this.id_cidade =
                String.IsNullOrEmpty(id_cidade) ? 0
                : Convert.ToInt32(id_cidade);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
