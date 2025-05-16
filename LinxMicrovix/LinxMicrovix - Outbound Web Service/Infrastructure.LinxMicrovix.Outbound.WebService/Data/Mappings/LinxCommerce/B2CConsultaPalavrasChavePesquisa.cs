using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisaTrustedMap : IEntityTypeConfiguration<B2CConsultaPalavrasChavePesquisa>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPalavrasChavePesquisa> builder)
        {
            builder.ToTable("B2CConsultaPalavrasChavePesquisa", "linx_microvix_commerce");

            builder.HasKey(e => e.id_b2c_palavras_chave_pesquisa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_palavras_chave_pesquisa)
                .HasColumnType("int");

            builder.Property(e => e.nome_colecao) 
                .HasColumnType("varchar(300)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class B2CConsultaPalavrasChavePesquisaRawMap : IEntityTypeConfiguration<B2CConsultaPalavrasChavePesquisa>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPalavrasChavePesquisa> builder)
        {
            builder.ToTable("B2CConsultaPalavrasChavePesquisa", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_b2c_palavras_chave_pesquisa)
                .HasColumnType("int");

            builder.Property(e => e.nome_colecao) 
                .HasColumnType("varchar(300)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
