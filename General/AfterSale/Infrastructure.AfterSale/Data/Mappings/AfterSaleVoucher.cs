using Domain.AfterSale.Entities;
using Domain.IntegrationsCore.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleVoucher : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Voucher));

            builder.ToTable("AfterSaleVouchers");

            builder.HasKey(x => x.redemption_code);

            builder
                .Property(x => x.redemption_code)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.giftcard_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.expiring_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
