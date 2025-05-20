using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisaMap : IEntityTypeConfiguration<B2CConsultaProdutosPalavrasChavePesquisa>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosPalavrasChavePesquisa> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosPalavrasChavePesquisa));

            builder.ToTable("B2CConsultaProdutosPalavrasChavePesquisa");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_b2c_palavras_chave_pesquisa_produtos);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

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
