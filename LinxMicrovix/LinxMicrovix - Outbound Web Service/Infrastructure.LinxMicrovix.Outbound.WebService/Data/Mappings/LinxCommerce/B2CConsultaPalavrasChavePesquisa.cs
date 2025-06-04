using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisaMap : IEntityTypeConfiguration<B2CConsultaPalavrasChavePesquisa>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPalavrasChavePesquisa> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPalavrasChavePesquisa));

            builder.ToTable("B2CConsultaPalavrasChavePesquisa");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_b2c_palavras_chave_pesquisa);
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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
