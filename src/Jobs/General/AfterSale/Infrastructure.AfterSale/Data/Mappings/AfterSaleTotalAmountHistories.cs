﻿using Microsoft.EntityFrameworkCore;
using Domain.AfterSale.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Schemas;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleTotalAmountHistories : IEntityTypeConfiguration<Domain.AfterSale.Entities.TotalAmountHistories>
    {
        public void Configure(EntityTypeBuilder<TotalAmountHistories> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(TotalAmountHistories));

            builder.ToTable("AfterSaleTotalAmountHistories");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder.Property(e => e.total_amount)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.refund_id)
                .HasColumnType("int");

            builder.Property(e => e.date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
