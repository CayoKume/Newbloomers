using Domain.AfterSale.Entities;
using Domain.IntegrationsCore.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleEcommerceMap : IEntityTypeConfiguration<Ecommerce>
    {
        public void Configure(EntityTypeBuilder<Ecommerce> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Ecommerce));

            builder.ToTable("AfterSaleEcommerces");

            if (schema != "untreated")
            {
                builder
                    .HasMany(x => x.reasons)
                    .WithOne()
                    .HasForeignKey(y => y.ecommerce_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasOne(x => x.address)
                    .WithMany()
                    .HasForeignKey(y => y.address_id)
                    .OnDelete(DeleteBehavior.NoAction); 
            }
            else
            {
                builder.Ignore(x => x.reasons);
                builder.Ignore(x => x.address);
            }

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.uuid)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder
                .Property(x => x.ecommerce_group_id)
                .HasColumnType("int");

            builder.Property(e => e.company_name)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.trade_name)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.display_name)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.url)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.is_active)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.phone)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.email)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.document)
                .HasColumnType("varchar(20)");

            builder
                .Property(x => x.address_id)
                .HasColumnType("int");

            builder
                .Property(x => x.maintenance_mode_global)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.last_order_report_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.is_test)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.segment)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.oauth_client_id)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.provider_id)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.registration_origin)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.brand_id)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.app_name)
                .HasColumnType("varchar(60)");
        }
    }
}
