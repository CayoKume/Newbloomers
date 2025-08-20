using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoPrincipalMap : IEntityTypeConfiguration<LinxMovimentoPrincipal>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoPrincipal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoPrincipal));

            builder.ToTable("LinxMovimentoPrincipal");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_movimento_principal);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_movimento_principal)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.codigoproduto_manutencao)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.id_resposta_venda)
                .HasColumnType("int");

            builder.Property(e => e.total_fidelidade_cashback)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.plano_fidelidade_cashback)
                .HasColumnType("int");

            builder.Property(e => e.remessa_pedido_compra)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_motivo_desconto)
                .HasColumnType("int");

            builder.Property(e => e.valor_nota)
                .HasColumnType("decimal(10,2)");
        }
    }
}
