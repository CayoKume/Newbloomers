using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxListagemBalancoMap : IEntityTypeConfiguration<LinxListagemBalanco>
    {
        public void Configure(EntityTypeBuilder<LinxListagemBalanco> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxListagemBalanco));

            builder.ToTable("LinxListagemBalanco");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_balanco);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_balanco)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.nome_arquivo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.processado)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.data_ultimo_processamento)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.qtde_produtos)
                .HasColumnType("int");

            builder.Property(e => e.qtde_itens)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
