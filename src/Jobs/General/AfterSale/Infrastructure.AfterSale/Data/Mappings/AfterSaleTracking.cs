using Domain.AfterSale.Entities;
using Domain.Core.Enums;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleTrackingMap : IEntityTypeConfiguration<Tracking>
    {
        public void Configure(EntityTypeBuilder<Tracking> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Tracking));

            builder.ToTable("AfterSaleTrackings");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.reverse_id)
                .HasColumnType("int");

            builder
                .Property(x => x.courier_contract_id)
                .HasColumnType("int");

            builder
                .Property(x => x.authorization_code)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.tracking_code)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.shipping_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.package_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.courier_name)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.tracking_url)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.expire_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.collect_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.requested_collect_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.status)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.message)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.status_updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.is_change_collect_to_post)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.type)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.qr_code)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.service_type)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.cte)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.delivery_deadline)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.extra_fields)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.deleted_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
