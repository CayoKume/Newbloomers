using Domain.AfterSale.Entities;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleTrackingHistoryMap : IEntityTypeConfiguration<TrackingHistory>
    {
        public void Configure(EntityTypeBuilder<TrackingHistory> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(TrackingHistory));

            builder.ToTable("AfterSaleTrackingHistories");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.tracking_id)
                .HasColumnType("int");

            builder
                .Property(x => x.status)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.message)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.status_updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.created_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.deleted_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
