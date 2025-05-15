using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasProviderColumnType<TProperty>(
            this PropertyBuilder<TProperty> builder,
            LogicalColumnType logicalType)
        {
            return builder.HasAnnotation("Custom:ColumnTypeMapper", logicalType.ToString());
        }
    }
}
