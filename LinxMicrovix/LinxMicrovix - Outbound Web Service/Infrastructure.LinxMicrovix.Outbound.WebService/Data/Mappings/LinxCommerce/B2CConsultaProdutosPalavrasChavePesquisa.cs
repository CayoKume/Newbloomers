using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisaTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosPalavrasChavePesquisa>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosPalavrasChavePesquisa> builder)
        {
            builder.ToTable("B2CConsultaProdutosPalavrasChavePesquisa", "linx_microvix_commerce");

            builder.HasKey(e => e.id_b2c_palavras_chave_pesquisa_produtos);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_palavras_chave_pesquisa_produtos)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_palavras_chave_pesquisa)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.descricao_b2c_palavras_chave_pesquisa)
                .HasColumnType("varchar(300)");
        }
    }

    public class B2CConsultaProdutosPalavrasChavePesquisaRawMap : IEntityTypeConfiguration<B2CConsultaProdutosPalavrasChavePesquisa>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosPalavrasChavePesquisa> builder)
        {
            builder.ToTable("B2CConsultaProdutosPalavrasChavePesquisa", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_palavras_chave_pesquisa_produtos)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_palavras_chave_pesquisa)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.descricao_b2c_palavras_chave_pesquisa)
                .HasColumnType("varchar(300)");
        }
    }
}
