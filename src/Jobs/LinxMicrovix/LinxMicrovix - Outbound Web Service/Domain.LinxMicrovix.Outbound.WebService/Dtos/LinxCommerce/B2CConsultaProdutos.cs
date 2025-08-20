namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutos
    {
        public string? codigoproduto { get; private set; }
        public string? referencia { get; private set; }
        public string? codauxiliar1 { get; private set; }
        public string? descricao_basica { get; private set; }
        public string? nome_produto { get; private set; }
        public string? peso_liquido { get; private set; }
        public string? codigo_setor { get; private set; }
        public string? codigo_linha { get; private set; }
        public string? codigo_marca { get; private set; }
        public string? codigo_colecao { get; private set; }
        public string? codigo_espessura { get; private set; }
        public string? codigo_grade1 { get; private set; }
        public string? codigo_grade2 { get; private set; }
        public string? unidade { get; private set; }
        public string? ativo { get; private set; }
        public string? codigo_classificacao { get; private set; }
        public string? dt_cadastro { get; private set; }
        public string? observacao { get; private set; }
        public string? cod_fornecedor { get; private set; }
        public string? dt_update { get; private set; }
        public string? altura_para_frete { get; private set; }
        public string? largura_para_frete { get; private set; }
        public string? comprimento_para_frete { get; private set; }
        public string? timestamp { get; private set; }
        public string? peso_bruto { get; private set; }
        public string? portal { get; private set; }
        public string? descricao_completa_commerce { get; private set; }
        public string? canais_ecommerce_publicados { get; private set; }
        public string? inicio_publicacao_produto { get; private set; }
        public string? fim_publicacao_produto { get; private set; }
        public string? codigo_integracao_oms { get; private set; }

        public B2CConsultaProdutos() { }

        public B2CConsultaProdutos(
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
            this.codigoproduto = codigoproduto;
            this.referencia = referencia;
            this.codauxiliar1 = codauxiliar1;
            this.descricao_basica = descricao_basica;
            this.nome_produto = nome_produto;
            this.peso_liquido = peso_liquido;
            this.codigo_setor = codigo_setor;
            this.codigo_linha = codigo_linha;
            this.codigo_marca = codigo_marca;
            this.codigo_colecao = codigo_colecao;
            this.codigo_espessura = codigo_espessura;
            this.codigo_grade1 = codigo_grade1;
            this.codigo_grade2 = codigo_grade2;
            this.unidade = unidade;
            this.ativo = ativo;
            this.codigo_classificacao = codigo_classificacao;
            this.dt_cadastro = dt_cadastro;
            this.observacao = observacao;
            this.cod_fornecedor = cod_fornecedor;
            this.dt_update = dt_update;
            this.altura_para_frete = altura_para_frete;
            this.largura_para_frete = largura_para_frete;
            this.comprimento_para_frete = comprimento_para_frete;
            this.timestamp = timestamp;
            this.peso_bruto = peso_bruto;
            this.portal = portal;
            this.descricao_completa_commerce = descricao_completa_commerce;
            this.canais_ecommerce_publicados = canais_ecommerce_publicados;
            this.inicio_publicacao_produto = inicio_publicacao_produto;
            this.fim_publicacao_produto = fim_publicacao_produto;
            this.codigo_integracao_oms = codigo_integracao_oms;
        }
    }
}